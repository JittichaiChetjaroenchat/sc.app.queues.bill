using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Customer.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.CustomerFacebook> CustomerFacebooks { get; set; }

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