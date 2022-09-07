using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Customer.Database.Configurations
{
    public class CustomerFacebookConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.CustomerFacebook>
    {
        public void Configure(EntityTypeBuilder<Models.CustomerFacebook> builder)
        {
            builder.ToTable(Constants.CustomerFacebook.TableName);
            builder.HasIndex(u => new { u.CustomerId, u.FacebookId })
                .IsUnique();
        }
    }
}