using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Database.Configurations
{
    public class PaymentVerificationConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.PaymentVerification>
    {
        public void Configure(EntityTypeBuilder<Models.PaymentVerification> builder)
        {
            builder.ToTable(Constants.PaymentVerification.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.PaymentId)
                .IsUnique();
        }
    }
}