using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillShippingTotalRuleConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillShippingTotalRule>
    {
        public void Configure(EntityTypeBuilder<Models.BillShippingTotalRule> builder)
        {
            builder.ToTable(Constants.BillShippingTotalRule.TableName);
        }
    }
}