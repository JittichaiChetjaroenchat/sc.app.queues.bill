using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Credit.Database.Models;

namespace SC.App.Queues.Bill.Business.Credit.Database.Configurations
{
    public class CreditTransactionConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<CreditTransaction>
    {
        public void Configure(EntityTypeBuilder<CreditTransaction> builder)
        {
            builder.ToTable(Constants.CreditTransaction.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasOne(a => a.Credit)
                .WithMany(b => b.CreditTransactions)
                .HasForeignKey(f => f.CreditId);
        }
    }
}