using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SC.App.Queues.Bill.Business.Credit.Database;
using SC.App.Queues.Bill.Business.Credit.Database.Models;
using SC.App.Queues.Bill.Business.Credit.Repositories.Interface;

namespace SC.App.Queues.Bill.Business.Credit.Repositories
{
    public class CreditExpenseTypeRepository : BaseRepository, ICreditExpenseTypeRepository
    {
        public CreditExpenseTypeRepository(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
        }

        public CreditExpenseType GetById(Guid id)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.CreditExpenseTypes
                    .FirstOrDefault(x => x.Id == id);
            }
        }

        public CreditExpenseType GetByCode(string code)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                return context.CreditExpenseTypes
                    .FirstOrDefault(x => x.Code == code);
            }
        }
    }
}