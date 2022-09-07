using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Order.Database.Models
{
    public class Order
    {
        [Key]
        [Column(Constants.Order.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Order.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid? ChannelId { get; set; }

        [Column(Constants.Order.Column.LiveId, TypeName = "varchar(36)")]
        public Guid? LiveId { get; set; }

        [Column(Constants.Order.Column.PostId, TypeName = "varchar(36)")]
        public Guid? PostId { get; set; }

        [Column(Constants.Order.Column.BillId, TypeName = "varchar(36)")]
        public Guid BillId { get; set; }

        [Column(Constants.Order.Column.BookingId, TypeName = "varchar(36)")]
        public Guid? BookingId { get; set; }

        [Column(Constants.Order.Column.ParcelId, TypeName = "varchar(36)")]
        public Guid? ParcelId { get; set; }

        [Column(Constants.Order.Column.ProductId, TypeName = "varchar(36)")]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.Order.Column.Code, TypeName = "varchar(16)")]
        public string Code { get; set; }

        [Column(Constants.Order.Column.Amount)]
        public int Amount { get; set; }

        [Column(Constants.Order.Column.UnitPrice, TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }

        [Column(Constants.Order.Column.Paid)]
        public bool Paid { get; set; }

        [Column(Constants.Order.Column.OrderStatusId, TypeName = "varchar(36)")]
        public Guid OrderStatusId { get; set; }

        [Column(Constants.Order.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Order.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Order.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Order.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        #region Relationships

        public virtual OrderStatus OrderStatus { get; set; }

        #endregion
    }
}