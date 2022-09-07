using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Courier.Database.Models
{
    public class Order
    {
        [Key]
        [Column(Constants.Order.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Order.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.Order.Column.RefId, TypeName = "varchar(36)")]
        public Guid RefId { get; set; }

        [Column(Constants.Order.Column.OrderStateStatusId, TypeName = "varchar(36)")]
        public Guid OrderStateStatusId { get; set; }

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

        public virtual OrderManifest OrderManifest { get; set; }

        public virtual OrderFeedback OrderFeedback { get; set; }

        #endregion
    }
}