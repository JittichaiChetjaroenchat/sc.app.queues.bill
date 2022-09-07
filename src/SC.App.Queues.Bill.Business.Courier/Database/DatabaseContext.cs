using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Courier.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderManifest> OrderManifests { get; set; }
        public DbSet<Models.OrderFeedback> OrderFeedbacks { get; set; }

        #region Masters

        public DbSet<Models.Courier> Couriers { get; set; }

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