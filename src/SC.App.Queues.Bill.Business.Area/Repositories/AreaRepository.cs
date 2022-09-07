using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Area.Database;
using SC.App.Queues.Bill.Business.Area.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Area.Repositories
{
    public class AreaRepository : BaseRepository, IAreaRepository
    {
        public AreaRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Database.Models.Area GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Areas
                    .FirstOrDefault(x => x.Id == id);
            }
        }
    }
}