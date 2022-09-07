using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SC.App.Queues.Bill.Common.Extensions;
using SC.Services.Bank.Client;

namespace SC.App.Queues.Bill.Client.BankService
{
    public class BankServiceManager : IBankServiceManager
    {
        private readonly IBankServiceClient _bankServiceClient;

        public BankServiceManager(
            IBankServiceClient bankServiceClient)
        {
            _bankServiceClient = bankServiceClient;
        }

        public async Task<ResponseOfListOfGetBankResponse> GetBanksAsync(HttpRequest request)
        {
            _bankServiceClient.SetAuthorization(request.GetAuthorization());
            _bankServiceClient.SetAcceptLanguage(request.GetAcceptLanguage());

            return await _bankServiceClient.Banks_GetByFilterAsync();
        }

        public async Task<ResponseOfGetSlipVerificationResponse> GetSlipVerificationAsync(HttpRequest request, string code)
        {
            _bankServiceClient.SetAuthorization(request.GetAuthorization());
            _bankServiceClient.SetAcceptLanguage(request.GetAcceptLanguage());

            return await _bankServiceClient.SlipVerifications_GetByCodeAsync(code);
        }

        public async Task<ResponseOfVerifySlipResponse> VerifySlipAsync(HttpRequest request, string url, ICollection<VerifySlipBankAccount> bankAccounts, decimal amount)
        {
            _bankServiceClient.SetAuthorization(request.GetAuthorization());
            _bankServiceClient.SetAcceptLanguage(request.GetAcceptLanguage());

            var payload = new VerifySlip
            {
                Url = url,
                Bank_accounts = bankAccounts,
                Amount = amount
            };

            return await _bankServiceClient.SlipVerifications_VerifyAsync(payload);
        }
    }
}