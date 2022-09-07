using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.App.Queues.Bill.Business.Courier.Database.Models;

namespace SC.App.Queues.Bill.Business.Courier.Database.Configurations
{
    public class OrderFeedbackConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<OrderFeedback>
    {
        public void Configure(EntityTypeBuilder<OrderFeedback> builder)
        {
            builder.ToTable(Constants.OrderFeedback.TableName);
            builder.HasIndex(u => new { u.OrderId })
                .IsUnique();
        }
    }
}