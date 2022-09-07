using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveCommentDescriptionConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.LiveCommentDescription>
    {
        public void Configure(EntityTypeBuilder<Models.LiveCommentDescription> builder)
        {
            builder.ToTable(Constants.LiveCommentDescription.TableName);
            builder.HasIndex(u => u.LiveCommentId)
                .IsUnique();
        }
    }
}