using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class BookingQueueConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BookingQueue>
    {
        public void Configure(EntityTypeBuilder<Models.BookingQueue> builder)
        {
            builder.ToTable(Constants.BookingQueue.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}