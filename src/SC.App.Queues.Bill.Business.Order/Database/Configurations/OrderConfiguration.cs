using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Order.Database.Configurations
{
    public class OrderConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Order>
    {
        public void Configure(EntityTypeBuilder<Models.Order> builder)
        {
            builder.ToTable(Constants.Order.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}