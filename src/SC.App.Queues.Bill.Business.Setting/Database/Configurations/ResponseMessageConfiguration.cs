using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SC.App.Queues.Bill.Business.Setting.Database.Configurations
{
    public class ResponseMessageConfiguration : BaseEntityTypeConfiguration, IEntityTypeConfiguration<Models.ResponseMessage>
    {
        public void Configure(EntityTypeBuilder<Models.ResponseMessage> builder)
        {
            builder.ToTable(Constants.ResponseMessage.TableName);
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.Property(x => x.UpdatedOn).HasDefaultValueSql(CURRENT_DATE);
            builder.HasIndex(u => u.ChannelId)
                .IsUnique();
        }
    }
}