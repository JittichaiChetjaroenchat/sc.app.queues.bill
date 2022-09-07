using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class PaymentVerificationStatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.PaymentVerificationStatus>
    {
        public void Configure(EntityTypeBuilder<Models.PaymentVerificationStatus> builder)
        {
            builder.ToTable(Constants.PaymentVerificationStatus.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}