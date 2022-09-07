using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class BookingUnlock
    {
        [Key]
        [Column(Constants.BookingUnlock.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.BookingUnlock.Column.LiveId, TypeName = "varchar(36)")]
        public Guid LiveId { get; set; }

        [Column(Constants.BookingUnlock.Column.LiveCommentorId, TypeName = "varchar(36)")]
        public Guid LiveCommentorId { get; set; }

        [Column(Constants.BookingUnlock.Column.Enabled)]
        public bool Enabled { get; set; }

        [Column(Constants.BookingUnlock.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        #region Relationships

        public virtual Live Live { get; set; }

        public virtual LiveCommentor LiveCommentor { get; set; }

        #endregion
    }
}