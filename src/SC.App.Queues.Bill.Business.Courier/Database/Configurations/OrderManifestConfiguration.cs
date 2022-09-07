using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Courier.Database.Models;

namespace SC.App.Queues.Bill.Business.Courier.Database.Configurations
{
    public class OrderManifestConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<OrderManifest>
    {
        public void Configure(EntityTypeBuilder<OrderManifest> builder)
        {
            builder.ToTable(Constants.OrderManifest.TableName);
            builder.HasIndex(u => new { u.OrderId })
                .IsUnique();
        }
    }
}