using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class OfferingStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.OfferingStatus>
    {
        public void Configure(EntityTypeBuilder<Models.OfferingStatus> builder)
        {
            builder.ToTable(Constants.OfferingStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}