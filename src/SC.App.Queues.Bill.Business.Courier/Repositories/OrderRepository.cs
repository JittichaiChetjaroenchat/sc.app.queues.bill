using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Courier.Database;
using SC.App.Queues.Bill.Business.Courier.Database.Models;
using SC.App.Queues.Bill.Business.Courier.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Courier.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Order GetByUniqueKey(Guid refId)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Orders
                    .Include(x => x.OrderManifest)
                    .ThenInclude(x => x.Courier)
                    .Include(x => x.OrderFeedback)
                    .FirstOrDefault(x => x.RefId == refId);
            }
        }
    }
}