using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Bill> Bills { get; set; }
        public DbSet<Models.BillDiscount> BillDiscounts { get; set; }
        public DbSet<Models.BillNotification> BillNotifications { get; set; }
        public DbSet<Models.BillPayment> BillPayments { get; set; }
        public DbSet<Models.BillRecipient> BillRecipients { get; set; }
        public DbSet<Models.Parcel> Parcels { get; set; }
        public DbSet<Models.Payment> Payments { get; set; }
        public DbSet<Models.PaymentVerification> PaymentVerifications { get; set; }
        public DbSet<Models.PaymentVerificationDetail> PaymentVerificationDetails { get; set; }

        #region Master

        public DbSet<Models.BillStatus> BillStatuses { get; set; }
        public DbSet<Models.PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Models.PaymentVerificationStatus> PaymentVerificationStatuses { get; set; }

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