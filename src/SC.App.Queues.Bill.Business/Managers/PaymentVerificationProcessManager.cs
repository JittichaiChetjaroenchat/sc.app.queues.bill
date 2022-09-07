using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SC.App.Queues.Bill.Business.Enums;
using SC.App.Queues.Bill.Business.Helpers;
using SC.App.Queues.Bill.Business.Managers.Interface;
using SC.App.Queues.Bill.Business.Mappers;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Client.BankService;
using SC.App.Queues.Bill.Common.Constants;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Managers
{
    public class PaymentVerificationProcessManager : IPaymentVerificationProcessManager
    {
        private readonly IBillRepository _billRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPaymentVerificationRepository _paymentVerificationRepository;
        private readonly IPaymentVerificationDetailRepository _paymentVerificationDetailRepository;
        private readonly IPaymentVerificationStatusRepository _paymentVerificationStatusRepository;
        private readonly Setting.Repositories.Interface.IBillingRepository _billingRepository;
        private readonly Setting.Repositories.Interface.IPaymentRepository _paymentSettingRepository;
        private readonly Order.Repositories.Interface.IOrderRepository _orderRepository;

        private readonly IBillProcessManager _billManager;
        private readonly IPaymentProcessManager _paymentManager;

        private readonly IBankServiceManager _bankServiceManager;

        private readonly IConfiguration _configuration;

        public PaymentVerificationProcessManager(
            IBillRepository billRepository,
            IPaymentRepository paymentRepository,
            IPaymentVerificationRepository paymentVerificationRepository,
            IPaymentVerificationDetailRepository paymentVerificationDetailRepository,
            IPaymentVerificationStatusRepository paymentVerificationStatusRepository,
            Order.Repositories.Interface.IOrderRepository orderRepository,
            Setting.Repositories.Interface.IBillingRepository billingRepository,
            Setting.Repositories.Interface.IPaymentRepository paymentSettingRepository,

            IBillProcessManager billManager,
            IPaymentProcessManager paymentManager,

            IBankServiceManager bankServiceManager,

            IConfiguration configuration)
        {
            _billRepository = billRepository;
            _paymentRepository = paymentRepository;
            _paymentVerificationRepository = paymentVerificationRepository;
            _paymentVerificationDetailRepository = paymentVerificationDetailRepository;
            _paymentVerificationStatusRepository = paymentVerificationStatusRepository;
            _orderRepository = orderRepository;
            _billingRepository = billingRepository;
            _paymentSettingRepository = paymentSettingRepository;

            _billManager = billManager;
            _paymentManager = paymentManager;

            _bankServiceManager = bankServiceManager;

            _configuration = configuration;
        }

        public async Task VerifyAsync(Guid paymentId)
        {
            try
            {
                // Get payment
                var payment = _paymentRepository.GetById(paymentId);
                if (payment == null)
                {
                    throw new SkipProcessException("No payment found.");
                }

                if (!payment.EvidenceId.HasValue)
                {
                    throw new SkipProcessException("No payment's evidence found.");
                }

                // Get bill
                var bill = _billRepository.GetById(payment.BillId);
                if (bill == null)
                {
                    throw new SkipProcessException("No bill found.");
                }

                // Get payment's setting
                var paymentSetting = _paymentSettingRepository.GetByChannelId(bill.ChannelId);
                if (paymentSetting == null)
                {
                    throw new SkipProcessException("No payment's setting found.");
                }

                // Get billing
                var billing = _billingRepository.GetByChannelId(bill.ChannelId);
                if (billing == null)
                {
                    throw new SkipProcessException("No billing found.");
                }

                Database.Models.PaymentVerification paymentVerification = null;
                Database.Models.PaymentVerificationStatus paymentVerificationStatus = null;
                EnumPaymentVerificationStatus enumPaymentVerificationStatus = EnumPaymentVerificationStatus.Unknown;

                // Get banks
                ICollection<Services.Bank.Client.GetBankResponse> banks = new List<Services.Bank.Client.GetBankResponse>();
                var getBanksResponse = await _bankServiceManager.GetBanksAsync(null);
                if (!BankServiceClientHelper.IsSuccess(getBanksResponse))
                {
                    throw new SkipProcessException("No banks found.");
                }
                else
                {
                    banks = getBanksResponse.Data;
                }

                // Get cost
                var orders = _orderRepository.GetByBillId(bill.Id);
                var payExtra = CostHelper.GetPayExtra(orders, bill.BillShipping, bill.Payments, bill.BillDiscount, bill.BillPayment);

                // Verify slip
                Services.Bank.Client.VerifySlipResponse verifySlip = null;
                var apiBaseUrl = _configuration.GetValue<string>(AppSettings.Services.BaseUrl);
                var paymentEvidenceUrl = $"{apiBaseUrl}/document/api/documents/{payment.EvidenceId.Value}/raw";
                var bankAccounts = PaymentVerificationHelper.Convert(banks, paymentSetting.PaymentBankAccounts);
                var verifySlipResponse = await _bankServiceManager.VerifySlipAsync(null, paymentEvidenceUrl, bankAccounts, payExtra);
                if (!BankServiceClientHelper.IsSuccess(verifySlipResponse))
                {
                    throw new SkipProcessException("No verify slip found.");
                }
                else
                {
                    verifySlip = verifySlipResponse.Data;
                }

                // Create/Update payment verification
                enumPaymentVerificationStatus = PaymentVerificationHelper.Get(verifySlip.Status);
                paymentVerification = _paymentVerificationRepository.GetByPaymentId(payment.Id);
                paymentVerificationStatus = _paymentVerificationStatusRepository.GetByCode(enumPaymentVerificationStatus.GetDescription());
                if (paymentVerification == null)
                {
                    paymentVerification = PaymentVerificationMapper.Map(paymentId, paymentVerificationStatus, null);
                    _paymentVerificationRepository.Add(paymentVerification);
                }
                else
                {
                    paymentVerification = PaymentVerificationMapper.Map(paymentVerification, paymentVerificationStatus, null);
                    _paymentVerificationRepository.Update(paymentVerification);
                }

                // Create payment verification's detail and confirm bill
                if (verifySlip != null && !verifySlip.Code.IsEmpty())
                {
                    // Get slip verification
                    Services.Bank.Client.GetSlipVerificationResponse getSlipVerification = null;
                    var getSlipVerificationResponse = await _bankServiceManager.GetSlipVerificationAsync(null, verifySlip.Code);
                    if (BankServiceClientHelper.IsSuccess(getSlipVerificationResponse))
                    {
                        getSlipVerification = getSlipVerificationResponse.Data;

                        if (getSlipVerification.Detail != null)
                        {
                            // Check duplicate or unbalance
                            var duplicateRecipients = _paymentVerificationRepository.GetDuplicateTos(getSlipVerification.Detail.Transaction_ref_no, bill.ChannelId, payment.Id);
                            var duplicateTos = PaymentVerificationDuplicateToMapper.Map(duplicateRecipients);
                            var isDuplicate = !duplicateTos.IsEmpty();
                            var isUnBalanceAmount = getSlipVerification.Detail.Amount != payExtra;
                            if (isDuplicate || isUnBalanceAmount)
                            {
                                if (isDuplicate)
                                {
                                    enumPaymentVerificationStatus = EnumPaymentVerificationStatus.Duplicate;
                                    paymentVerification.DuplicateTo = duplicateTos.Length > 1024 ? duplicateTos.Substring(0, 1024) : duplicateTos;
                                }

                                if (isUnBalanceAmount)
                                {
                                    enumPaymentVerificationStatus = EnumPaymentVerificationStatus.IncorrectAmount;
                                    paymentVerification.UnBalanceAmount = getSlipVerification.Detail.Amount - payExtra;
                                }

                                paymentVerificationStatus = _paymentVerificationStatusRepository.GetByCode(enumPaymentVerificationStatus.GetDescription());
                                paymentVerification = PaymentVerificationMapper.Map(paymentVerification, paymentVerificationStatus, null);
                                _paymentVerificationRepository.Update(paymentVerification);
                            }

                            // Create payment verification's detail
                            var paymentVerificationDetail = PaymentVerificationDetailMapper.Map(paymentVerification.Id, getSlipVerification.Detail);
                            _paymentVerificationDetailRepository.Add(paymentVerificationDetail);

                            // Update payment
                            payment.Amount = getSlipVerification.Detail.Amount;
                            payment.PayOn = getSlipVerification.Detail.Transaction_date.Date;
                            _paymentRepository.Update(payment);
                        }

                        if (enumPaymentVerificationStatus == EnumPaymentVerificationStatus.Verified)
                        {
                            // Accept payment
                            await _paymentManager.AcceptPaymentAsync(payment.Id);

                            // Confirm bill
                            if (paymentSetting.IsConfirmBillAutomatic)
                            {
                                await _billManager.ConfirmBillAsync(bill.Id);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}