using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveOptionConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.LiveOption>
    {
        public void Configure(EntityTypeBuilder<Models.LiveOption> builder)
        {
            builder.ToTable(Constants.LiveOption.TableName);
            builder.HasIndex(u => u.LiveId)
                .IsUnique();
        }
    }
}