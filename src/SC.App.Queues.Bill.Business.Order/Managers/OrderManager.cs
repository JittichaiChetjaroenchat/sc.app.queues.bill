using System;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Order.Enums;
using SC.App.Queues.Bill.Business.Order.Managers.Interface;
using SC.App.Queues.Bill.Business.Order.Repositories.Interface;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Order.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderManager(
            IOrderRepository orderRepository,
            IOrderStatusRepository orderStatusRepository)
        {
            _orderRepository = orderRepository;
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task ConfirmOrderAsync(Guid billId)
        {
            try
            {
                // Get orders
                var orders = _orderRepository.GetByBillIdWithStatus(billId, EnumOrderStatus.Pending);
                if (!orders.IsEmpty())
                {
                    // Get order's status
                    var orderStatus = _orderStatusRepository.GetByCode(EnumOrderStatus.Confirm.GetDescription());

                    // Update orders
                    foreach (var order in orders)
                    {
                        order.OrderStatusId = orderStatus.Id;
                        order.Paid = true;
                        order.UpdatedBy = Guid.Empty;
                        order.UpdatedOn = DateTime.Now;
                    }

                    _orderRepository.Updates(orders);
                }

                await Task.CompletedTask;
            }
            catch
            {
                throw;
            }
        }
    }
}