using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Order.Managers.Interface
{
    public interface IOrderManager
    {
        Task ConfirmOrderAsync(Guid billId);
    }
}