using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class PaymentStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.PaymentStatus>
    {
        public void Configure(EntityTypeBuilder<Models.PaymentStatus> builder)
        {
            builder.ToTable(Constants.PaymentStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}