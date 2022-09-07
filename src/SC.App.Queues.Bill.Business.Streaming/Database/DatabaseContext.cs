using Microsoft.EntityFrameworkCore;

namespace SC.App.Queues.Bill.Business.Streaming.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Models.Offering> Offerings { get; set; }
        public DbSet<Models.Booking> Bookings { get; set; }
        public DbSet<Models.BookingQueue> BookingQueues { get; set; }
        public DbSet<Models.BookingUnlock> BookingUnlocks { get; set; }
        public DbSet<Models.Live> Lives { get; set; }
        public DbSet<Models.LiveOption> LiveOptions { get; set; }
        public DbSet<Models.LiveComment> LiveComments { get; set; }
        public DbSet<Models.LiveCommentDescription> LiveCommentDescription { get; set; }
        public DbSet<Models.LiveCommentor> LiveCommentors { get; set; }

        #region Masters

        public DbSet<Models.BookingChannel> BookingChannels { get; set; }
        public DbSet<Models.LiveStatus> LiveStatuses { get; set; }
        public DbSet<Models.OfferingStatus> OfferingStatuses { get; set; }

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