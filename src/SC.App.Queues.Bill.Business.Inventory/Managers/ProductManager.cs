using System;
using System.Linq;
using System.Threading.Tasks;
using SC.App.Queues.Bill.Business.Inventory.Managers.Interface;
using SC.App.Queues.Bill.Business.Inventory.Repositories.Interface;
using SC.App.Queues.Bill.Business.Order.Repositories.Interface;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Inventory.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductManager(
            IProductRepository productRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task UpdateStockAsync(Guid billId)
        {
            try
            {
                // Get pending orders
                var orders = _orderRepository.GetByBillIdWithStatus(billId, Order.Enums.EnumOrderStatus.Pending);

                // Update product's stock
                var productIds = orders
                    .Select(x => x.ProductId)
                    .ToArray();
                var products = _productRepository.GetByIds(productIds);
                foreach (var product in products)
                {
                    var order = orders
                        .FirstOrDefault(x => x.ProductId == product.Id);
                    if (order != null)
                    {
                        product.Amount += -order.Amount;
                        product.UpdatedOn = DateTime.Now;
                    }
                }

                if (!products.IsEmpty())
                {
                    _productRepository.Updates(products);
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