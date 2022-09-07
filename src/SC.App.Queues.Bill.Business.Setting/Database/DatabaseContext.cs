using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Setting.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Billing> Billings { get; set; }
        public DbSet<Models.Payment> Payments { get; set; }
        public DbSet<Models.PaymentBankAccount> PaymentBankAccounts { get; set; }
        public DbSet<Models.ResponseMessage> ResponseMessages { get; set; }
        public DbSet<Models.Preferences> Preferences { get; set; }

        #region Masters

        public DbSet<Models.Status> Statuses { get; set; }

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