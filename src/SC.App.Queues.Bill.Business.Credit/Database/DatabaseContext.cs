using Microsoft.EntityFrameworkCore;
using SC.App.Queues.Bill.Business.Credit.Database.Models;

namespace SC.App.Queues.Bill.Business.Credit.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Credit> Credits { get; set; }
        public DbSet<CreditTransaction> CreditTransactions { get; set; }

        #region Master

        public DbSet<CreditExpenseType> CreditExpenseTypes { get; set; }

        #endregion

        /// <summary>
        /// Initialize database context
        /// </summary>
        /// <param name="options">The options</param>
        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}