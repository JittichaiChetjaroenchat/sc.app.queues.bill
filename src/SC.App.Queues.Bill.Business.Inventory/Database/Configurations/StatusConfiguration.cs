using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Inventory.Database.Models;

namespace SC.App.Queues.Bill.Business.Inventory.Database.Configurations
{
    public class StatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(Constants.Status.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}