using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Customer.Database;
using SC.App.Queues.Bill.Business.Customer.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Customer.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Database.Models.Customer GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Customers
                    .Include(x => x.CustomerFacebook)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public void Update(Database.Models.Customer customer)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}