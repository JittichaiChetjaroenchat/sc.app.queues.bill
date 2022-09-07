using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class BillPaymentTypeConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.BillPaymentType>
    {
        public void Configure(EntityTypeBuilder<Models.BillPaymentType> builder)
        {
            builder.ToTable(Constants.BillPaymentType.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}