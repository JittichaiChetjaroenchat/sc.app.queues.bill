using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Courier.Database.Configurations
{
    public class CourierConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Courier>
    {
        public void Configure(EntityTypeBuilder<Models.Courier> builder)
        {
            builder.ToTable(Constants.Courier.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}