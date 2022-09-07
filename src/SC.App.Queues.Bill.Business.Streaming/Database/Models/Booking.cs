using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class Booking
    {
        [Key]
        [Column(Constants.Booking.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Booking.Column.BookingChannelId, TypeName = "varchar(36)")]
        public Guid BookingChannelId { get; set; }

        [Column(Constants.Booking.Column.OfferingId, TypeName = "varchar(36)")]
        public Guid OfferingId { get; set; }

        [Column(Constants.Booking.Column.LiveCommentId, TypeName = "varchar(36)")]
        public Guid LiveCommentId { get; set; }

        [Column(Constants.Booking.Column.Amount)]
        public int Amount { get; set; }

        [Column(Constants.Booking.Column.IsCancelled)]
        public bool IsCancelled { get; set; }

        [Column(Constants.Booking.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        #region Relationships

        public virtual BookingChannel BookingChannel { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual LiveComment LiveComment { get; set; }

        #endregion
    }
}