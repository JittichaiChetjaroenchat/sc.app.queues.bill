using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillShippingFreeRuleConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillShippingFreeRule>
    {
        public void Configure(EntityTypeBuilder<Models.BillShippingFreeRule> builder)
        {
            builder.ToTable(Constants.BillShippingFreeRule.TableName);
        }
    }
}