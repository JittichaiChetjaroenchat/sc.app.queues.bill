using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Setting.Database.Models;

namespace SC.App.Queues.Bill.Business.Setting.Database.Configurations
{
    public class PaymentBankAccountConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<PaymentBankAccount>
    {
        public void Configure(EntityTypeBuilder<PaymentBankAccount> builder)
        {
            builder.ToTable(Constants.PaymentBankAccount.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}