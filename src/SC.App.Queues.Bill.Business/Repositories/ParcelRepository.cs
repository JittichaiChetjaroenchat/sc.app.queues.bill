using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Repositories.Interface;
using SC.App.Queues.Bill.Database.Models;

namespace SC.App.Queues.Bill.Business.Repositories
{
    public class ParcelRepository : BaseRepository, IParcelRepository
    {
        public ParcelRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Parcel GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Database.DatabaseContext>();

                return context.Parcels
                    .FirstOrDefault(x => x.Id == id);
            }
        }
    }
}