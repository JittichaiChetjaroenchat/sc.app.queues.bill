using System;
using System.Threading.Tasks;

namespace SC.App.Queues.Bill.Business.Inventory.Managers.Interface
{
    public interface IProductManager
    {
        Task UpdateStockAsync(Guid billId);
    }
}