using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Setting.Database.Configurations
{
    public class StatusConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Status>
    {
        public void Configure(EntityTypeBuilder<Models.Status> builder)
        {
            builder.ToTable(Constants.Status.TableName);
            builder.HasIndex(u => u.Code)
                .IsUnique();
        }
    }
}