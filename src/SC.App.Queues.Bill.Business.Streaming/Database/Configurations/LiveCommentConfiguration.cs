using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Configurations
{
    public class LiveCommentConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.LiveComment>
    {
        public void Configure(EntityTypeBuilder<Models.LiveComment> builder)
        {
            builder.ToTable(Constants.LiveComment.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.MessageId)
                .IsUnique();
        }
    }
}