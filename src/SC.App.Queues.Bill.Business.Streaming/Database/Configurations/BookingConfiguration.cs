using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class BookingConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Booking>
    {
        public void Configure(EntityTypeBuilder<Models.Booking> builder)
        {
            builder.ToTable(Constants.Booking.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}