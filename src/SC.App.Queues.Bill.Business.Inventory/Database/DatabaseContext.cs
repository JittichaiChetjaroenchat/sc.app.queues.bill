using Microsoft.EntityFrameworkCore;
using SC.App.Queues.Bill.Business.Inventory.Database.Models;

namespace SC.App.Queues.Bill.Business.Inventory.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        #region Master

        public DbSet<Status> Statuses { get; set; }

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