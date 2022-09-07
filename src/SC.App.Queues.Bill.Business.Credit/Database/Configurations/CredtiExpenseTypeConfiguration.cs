using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Credit.Database.Models;

namespace SC.App.Queues.Bill.Business.Credit.Database.Configurations
{
    public class CreditExpenseTypeConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<CreditExpenseType>
    {
        public void Configure(EntityTypeBuilder<CreditExpenseType> builder)
        {
            builder.ToTable(Constants.CreditExpenseType.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}