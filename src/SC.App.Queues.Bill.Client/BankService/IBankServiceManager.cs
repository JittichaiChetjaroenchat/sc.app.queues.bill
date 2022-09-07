using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SC.Services.Bank.Client;

namespace SC.App.Queues.Bill.Client.BankService
{
    public interface IBankServiceManager
    {
        Task<ResponseOfListOfGetBankResponse> GetBanksAsync(HttpRequest request);

        Task<ResponseOfGetSlipVerificationResponse> GetSlipVerificationAsync(HttpRequest request, string code);

        Task<ResponseOfVerifySlipResponse> VerifySlipAsync(HttpRequest request, string url, ICollection<VerifySlipBankAccount> bankAccounts, decimal amount);
    }
}