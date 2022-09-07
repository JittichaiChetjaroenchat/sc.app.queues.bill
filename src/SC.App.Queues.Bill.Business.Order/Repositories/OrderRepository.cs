using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Order.Database;
using SC.App.Queues.Bill.Business.Order.Enums;
using SC.App.Queues.Bill.Business.Order.Repositories.Interface;
using SC.App.Queues.Bill.Lib.Extensions;

namespace SC.App.Queues.Bill.Business.Order.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public List<Database.Models.Order> GetByBillId(Guid billId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Orders
                    .Include(x => x.OrderStatus)
                    .Where(x => x.BillId == billId)
                    .OrderByDescending(x => x.CreatedOn)
                    .ToList();
            }
        }

        public List<Database.Models.Order> GetByBillIdWithStatus(Guid billId, EnumOrderStatus status)
        {
            var statusCode = status.GetDescription();

            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Orders
                    .Include(x => x.OrderStatus)
                    .OrderByDescending(x => x.CreatedOn)
                    .Where(x => x.BillId == billId)
                    .Where(x => x.OrderStatus != null && x.OrderStatus.Code == status.GetDescription())
                    .ToList();
            }
        }

        public void Updates(List<Database.Models.Order> orders)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                foreach (var order in orders)
                {
                    context.Entry(order).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }
    }
}
