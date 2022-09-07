using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Credit.Enums;

namespace SC.App.Queues.Bill.Business.Credit.Managers.Interface
{
    public interface ICreditManager
    {
        Task<bool> CheckAvailableAsync(Guid channelId, EnumCreditExpenseType expenseType, decimal amount);

        Task UpdateAsync(Guid channelId, EnumCreditExpenseType expenseType, decimal amount, string remark);
    }
}