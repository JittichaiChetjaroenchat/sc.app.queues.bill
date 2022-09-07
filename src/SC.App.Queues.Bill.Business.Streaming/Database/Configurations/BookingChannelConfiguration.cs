using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class BookingChannelConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BookingChannel>
    {
        public void Configure(EntityTypeBuilder<Models.BookingChannel> builder)
        {
            builder.ToTable(Constants.BookingChannel.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}