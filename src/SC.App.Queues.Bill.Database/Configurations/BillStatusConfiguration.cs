using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillStatus>
    {
        public void Configure(EntityTypeBuilder<Models.BillStatus> builder)
        {
            builder.ToTable(Constants.BillStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}