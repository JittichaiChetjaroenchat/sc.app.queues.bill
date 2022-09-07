using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class BookingQueue
    {
        [Key]
        [Column(Constants.BookingQueue.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.BookingQueue.Column.BookingChannelId, TypeName = "varchar(36)")]
        public Guid BookingChannelId { get; set; }

        [Column(Constants.BookingQueue.Column.OfferingId, TypeName = "varchar(36)")]
        public Guid OfferingId { get; set; }

        [Column(Constants.BookingQueue.Column.LiveCommentId, TypeName = "varchar(36)")]
        public Guid LiveCommentId { get; set; }

        [Column(Constants.BookingQueue.Column.Amount)]
        public int Amount { get; set; }

        [Column(Constants.BookingQueue.Column.IsConfirmed)]
        public bool? IsConfirmed { get; set; }

        [Column(Constants.BookingQueue.Column.IsCancelled)]
        public bool? IsCancelled { get; set; }

        [Column(Constants.BookingQueue.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.BookingQueue.Column.ExpiredOn, TypeName = "datetime")]
        public DateTime ExpiredOn { get; set; }

        #region Relationships

        public virtual BookingChannel BookingChannel { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual LiveComment LiveComment { get; set; }

        #endregion
    }
}