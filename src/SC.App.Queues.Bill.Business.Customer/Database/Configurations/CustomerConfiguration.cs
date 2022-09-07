using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Customer.Database.Configurations
{
    public class CustomerConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Customer>
    {
        public void Configure(EntityTypeBuilder<Models.Customer> builder)
        {
            builder.ToTable(Constants.Customer.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
        }
    }
}