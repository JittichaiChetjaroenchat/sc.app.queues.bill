using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class BookingUnlockConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BookingUnlock>
    {
        public void Configure(EntityTypeBuilder<Models.BookingUnlock> builder)
        {
            builder.ToTable(Constants.BookingUnlock.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => new { u.LiveId, u.LiveCommentorId })
                .IsUnique();
        }
    }
}