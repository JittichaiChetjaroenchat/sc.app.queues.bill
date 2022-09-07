using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveCommentorConfiugration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.LiveCommentor>
    {
        public void Configure(EntityTypeBuilder<Models.LiveCommentor> builder)
        {
            builder.ToTable(Constants.LiveCommentor.TableName);
            builder.HasIndex(u => u.ClientId)
                .IsUnique();
        }
    }
}