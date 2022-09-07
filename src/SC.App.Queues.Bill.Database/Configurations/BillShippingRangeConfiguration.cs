using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillShippingRangeConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillShippingRange>
    {
        public void Configure(EntityTypeBuilder<Models.BillShippingRange> builder)
        {
            builder.ToTable(Constants.BillShippingRange.TableName);
            builder.HasOne(a => a.BillShippingRangeRule)
                .WithMany(b => b.BillShippingRanges)
                .HasForeignKey(f => f.ShippingRangeRuleId);
        }
    }
}