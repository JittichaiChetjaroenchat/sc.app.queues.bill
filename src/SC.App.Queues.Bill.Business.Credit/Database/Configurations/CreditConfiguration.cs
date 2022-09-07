using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Credit.Database.Configurations
{
    public class CreditConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Credit>
    {
        public void Configure(EntityTypeBuilder<Models.Credit> builder)
        {
            builder.ToTable(Constants.Credit.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}