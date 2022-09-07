using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.LiveStatus>
    {
        public void Configure(EntityTypeBuilder<Models.LiveStatus> builder)
        {
            builder.ToTable(Constants.LiveStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}