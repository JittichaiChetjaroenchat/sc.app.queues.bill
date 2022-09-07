using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class OfferingConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Offering>
    {
        public void Configure(EntityTypeBuilder<Models.Offering> builder)
        {
            builder.ToTable(Constants.Offering.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => new { u.LiveId, u.Code })
                .IsUnique();
        }
    }
}