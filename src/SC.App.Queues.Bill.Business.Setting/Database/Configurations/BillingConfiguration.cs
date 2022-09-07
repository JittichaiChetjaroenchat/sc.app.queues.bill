using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Setting.Database.Models;

namespace SC.App.Queues.Bill.Business.Setting.Database.Configurations
{
    public class BillingConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Billing>
    {
        public void Configure(EntityTypeBuilder<Billing> builder)
        {
            builder.ToTable(Constants.Billing.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.ChannelId)
                .IsUnique();
        }
    }
}