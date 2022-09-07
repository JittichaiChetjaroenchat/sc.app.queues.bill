using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillPaymentConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillPayment>
    {
        public void Configure(EntityTypeBuilder<Models.BillPayment> builder)
        {
            builder.ToTable(Constants.BillPayment.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.BillId)
                .IsUnique();
        }
    }
}