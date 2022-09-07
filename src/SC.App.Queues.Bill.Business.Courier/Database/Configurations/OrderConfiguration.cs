using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Courier.Database.Models;

namespace SC.App.Queues.Bill.Business.Courier.Database.Configurations
{
    public class OrderConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(Constants.Order.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => new { u.RefId })
                .IsUnique();
        }
    }
}