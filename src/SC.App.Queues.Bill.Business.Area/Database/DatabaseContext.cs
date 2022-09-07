using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Area.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Area> Areas { get; set; }

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