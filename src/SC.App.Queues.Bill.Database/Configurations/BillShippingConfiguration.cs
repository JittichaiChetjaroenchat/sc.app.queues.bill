using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillShippingConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillShipping>
    {
        public void Configure(EntityTypeBuilder<Models.BillShipping> builder)
        {
            builder.ToTable(Constants.BillShipping.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.BillId)
                .IsUnique();
        }
    }
}