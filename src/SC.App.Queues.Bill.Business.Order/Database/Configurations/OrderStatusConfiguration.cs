using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Order.Database.Configurations
{
    public class OrderStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.OrderStatus>
    {
        public void Configure(EntityTypeBuilder<Models.OrderStatus> builder)
        {
            builder.ToTable(Constants.OrderStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}