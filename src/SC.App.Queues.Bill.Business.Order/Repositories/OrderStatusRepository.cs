using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Order.Database;
using SC.App.Queues.Bill.Business.Order.Database.Models;
using SC.App.Queues.Bill.Business.Order.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Order.Repositories
{
    public class OrderStatusRepository : BaseRepository, IOrderStatusRepository
    {
        public OrderStatusRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public OrderStatus GetByCode(string code)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.OrderStatuses
                    .FirstOrDefault(x => x.Code == code);
            }
        }
    }
}