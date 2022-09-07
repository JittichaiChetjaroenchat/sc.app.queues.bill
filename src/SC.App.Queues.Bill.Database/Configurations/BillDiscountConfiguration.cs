using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillDiscountConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillDiscount>
    {
        public void Configure(EntityTypeBuilder<Models.BillDiscount> builder)
        {
            builder.ToTable(Constants.BillDiscount.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.BillId)
                .IsUnique();
        }
    }
}