using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class BillStatusRepository : BaseRepository, IBillStatusRepository
    {
        public BillStatusRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public BillStatus GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.BillStatuses
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public BillStatus GetByCode(string code)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.BillStatuses
                    .FirstOrDefault(x => x.Code == code);
            }
        }
    }
}