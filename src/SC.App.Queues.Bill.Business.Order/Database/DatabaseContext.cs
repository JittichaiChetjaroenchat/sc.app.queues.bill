using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Order.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Order> Orders { get; set; }

        #region Master

        public DbSet<Models.OrderStatus> OrderStatuses { get; set; }

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