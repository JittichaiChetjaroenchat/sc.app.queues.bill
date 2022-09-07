using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillShippingRangeRuleConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillShippingRangeRule>
    {
        public void Configure(EntityTypeBuilder<Models.BillShippingRangeRule> builder)
        {
            builder.ToTable(Constants.BillShippingRangeRule.TableName);
        }
    }
}