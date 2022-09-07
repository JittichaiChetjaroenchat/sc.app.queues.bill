using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Live>
    {
        public void Configure(EntityTypeBuilder<Models.Live> builder)
        {
            builder.ToTable(Constants.Live.TableName);
            builder.Property(x => x.StartedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.LiveId)
                .IsUnique();
        }
    }
}