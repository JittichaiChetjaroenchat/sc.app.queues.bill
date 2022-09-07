using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Inventory.Database;
using SC.App.Queues.Bill.Business.Inventory.Database.Models;
using SC.App.Queues.Bill.Business.Inventory.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Inventory.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public Product GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Products
                    .Include(x => x.Status)
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Product> GetByIds(Guid[] ids)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.Products
                    .Include(x => x.Status)
                    .Where(x => ids.Contains(x.Id))
                    .ToList();
            }
        }

        public void Updates(List<Product> products)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                foreach (var product in products)
                {
                    context.Entry(product).State = EntityState.Modified;
                }

                context.SaveChanges();
            }
        }
    }
}