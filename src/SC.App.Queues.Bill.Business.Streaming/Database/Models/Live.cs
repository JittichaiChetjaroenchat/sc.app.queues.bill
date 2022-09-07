using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class Live
    {
        [Key]
        [Column(Constants.Live.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Live.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.Live.Column.LiveId, TypeName = "varchar(16)")]
        public string LiveId { get; set; }

        [MaxLength(16)]
        [Column(Constants.Live.Column.TaskId, TypeName = "varchar(16)")]
        public string TaskId { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.Live.Column.Title, TypeName = "varchar(128)")]
        public string Title { get; set; }

        [MaxLength(256)]
        [Column(Constants.Live.Column.Description, TypeName = "varchar(256)")]
        public string Description { get; set; }

        [Column(Constants.Live.Column.LiveStatusId, TypeName = "varchar(36)")]
        public Guid LiveStatusId { get; set; }

        [Column(Constants.Live.Column.StartedOn, TypeName = "datetime")]
        public DateTime StartedOn { get; set; }

        [Column(Constants.Live.Column.EndedOn, TypeName = "datetime")]
        public DateTime? EndedOn { get; set; }

        #region Relationships

        public virtual LiveOption LiveOption { get; set; }
        public virtual LiveStatus LiveStatus { get; set; }

        #endregion
    }
}