using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Area.Database.Configurations
{
    public class AreaConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.Area>
    {
        public void Configure(EntityTypeBuilder<Models.Area> builder)
        {
            builder.ToTable(Constants.Area.TableName);
            builder.HasIndex(u => new { u.Province, u.District, u.SubDistrict, u.PostalCode })
                .IsUnique();
        }
    }
}