using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Credit.Enums;
using SC.App.Queues.Bill.Business.Credit.Helpers;
using SC.App.Queues.Bill.Business.Credit.Managers.Interface;
using SC.App.Queues.Bill.Business.Credit.Repositories.Interface;
using SC.App.Queues.Bill.Common.Exceptions;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Credit.Managers
{
    public class CreditManager : ICreditManager
    {
        private readonly ICreditRepository _creditRepository;
        private readonly ICreditTransactionRepository _creditTransactionRepository;
        private readonly ICreditExpenseTypeRepository _creditExpenseTypeRepository;

        public CreditManager(
            ICreditRepository creditRepository,
            ICreditTransactionRepository creditTransactionRepository,
            ICreditExpenseTypeRepository creditExpenseTypeRepository)
        {
            _creditRepository = creditRepository;
            _creditTransactionRepository = creditTransactionRepository;
            _creditExpenseTypeRepository = creditExpenseTypeRepository;
        }

        public async Task<bool> CheckAvailableAsync(Guid channelId, EnumCreditExpenseType expenseType, decimal amount)
        {
            var isAvailable = false;

            try
            {
                // Get credit
                var credit = _creditRepository.GetByChannelId(channelId);
                if (credit == null)
                {
                    throw new SkipProcessException("No credit found.");
                }

                switch (expenseType)
                {
                    case EnumCreditExpenseType.Billing:
                        isAvailable = credit.Balance >= amount;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }

            return await Task.FromResult(isAvailable);
        }

        public async Task UpdateAsync(Guid channelId, EnumCreditExpenseType expenseType, decimal amount, string remark)
        {
            try
            {
                // Get credit
                var credit = _creditRepository.GetByChannelId(channelId);
                if (credit == null)
                {
                    throw new SkipProcessException("No credit found.");
                }

                // Get credit's expense type
                var creditExpenseType = _creditExpenseTypeRepository.GetByCode(expenseType.GetDescription());
                if (creditExpenseType == null)
                {
                    throw new SkipProcessException("No credit's expense type found.");
                }

                // Update credit
                credit.Balance = CalculationHelper.Calculate(credit.Balance, amount);
                credit.UpdatedBy = Guid.Empty;
                credit.UpdatedOn = DateTime.Now;

                _creditRepository.Update(credit);

                // Save transaction
                var newCreditTransaction = new Database.Models.CreditTransaction
                {
                    CreditId = credit.Id,
                    CreditExpenseTypeId = creditExpenseType.Id,
                    Amount = amount,
                    Remark = remark,
                    CreatedBy = Guid.Empty
                };
                _creditTransactionRepository.Add(newCreditTransaction);

                await Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
    }
}