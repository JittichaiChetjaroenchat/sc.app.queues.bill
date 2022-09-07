using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveComment
    {
        [Key]
        [Column(Constants.LiveComment.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.LiveComment.Column.LiveId, TypeName = "varchar(36)")]
        public Guid LiveId { get; set; }

        [Column(Constants.LiveComment.Column.LiveCommentorId, TypeName = "varchar(36)")]
        public Guid LiveCommentorId { get; set; }

        [Required]
        [MaxLength(36)]
        [Column(Constants.LiveComment.Column.MessageId, TypeName = "varchar(36)")]
        public string MessageId { get; set; }

        [Required]
        [MaxLength(65535)]
        [Column(Constants.LiveComment.Column.Message, TypeName = "text")]
        public string Message { get; set; }

        [Column(Constants.LiveComment.Column.IsProcessed)]
        public bool IsProcessed { get; set; }

        [Column(Constants.LiveComment.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        #region Relationships

        public virtual Live Live { get; set; }

        public virtual LiveCommentDescription LiveCommentDescription { get; set; }

        public virtual LiveCommentor LiveCommentor { get; set; }

        #endregion
    }
}