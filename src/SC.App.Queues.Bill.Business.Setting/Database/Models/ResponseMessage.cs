using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class ResponseMessage
    {
        [Key]
        [Column(Constants.ResponseMessage.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.ResponseMessage.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.ResponseMessage.Column.IsComplete)]
        public bool IsComplete { get; set; }

        [Column(Constants.ResponseMessage.Column.StatusId, TypeName = "varchar(36)")]
        public Guid StatusId { get; set; }

        [Column(Constants.ResponseMessage.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.ResponseMessage.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.ResponseMessage.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.ResponseMessage.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [Column(Constants.ResponseMessage.Column.MessagingMethodId, TypeName = "varchar(36)")]
        public Guid MessagingMethodId { get; set; }

        [Column(Constants.ResponseMessage.Column.MessagingRateId, TypeName = "varchar(36)")]
        public Guid MessagingRateId { get; set; }

        [Column(Constants.ResponseMessage.Column.MessagingDelay)]
        public int MessagingDelay { get; set; }

        [Column(Constants.ResponseMessage.Column.Enabled)]
        public bool Enabled { get; set; }

        [Column(Constants.ResponseMessage.Column.VoiceNotificationEnabled)]
        public bool VoiceNotificationEnabled { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.ResponseMessage.Column.VoiceNotificationSuffix, TypeName = "varchar(16)")]
        public string VoiceNotificationSuffix { get; set; }

        #region Request offer's link

        [Required]
        [MaxLength(5)]
        [Column(Constants.ResponseMessage.Column.RequestOfferLinkCode, TypeName = "varchar(5)")]
        public string RequestOfferLinkCode { get; set; }

        [Column(Constants.ResponseMessage.Column.RequestOfferLinkEnabled)]
        public bool RequestOfferLinkEnabled { get; set; }

        #endregion

        #region Order confirm

        [Column(Constants.ResponseMessage.Column.OrderConfirmReactionEnabled)]
        public bool OrderConfirmReactionEnabled { get; set; }

        [Column(Constants.ResponseMessage.Column.OrderConfirmImageEnabled)]
        public bool OrderConfirmImageEnabled { get; set; }

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.OrderConfirmFirstMessage, TypeName = "varchar(512)")]
        public string OrderConfirmFirstMessage { get; set; }

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.OrderConfirmNextMessage, TypeName = "varchar(512)")]
        public string OrderConfirmNextMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.OrderConfirmMessageEnabled)]
        public bool OrderConfirmMessageEnabled { get; set; }

        #endregion

        #region Order cancel

        [Column(Constants.ResponseMessage.Column.OrderCancelImageEnabled)]
        public bool OrderCancelImageEnabled { get; set; }

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.OrderCancelMessage, TypeName = "varchar(512)")]
        public string OrderCancelMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.OrderCancelMessageEnabled)]
        public bool OrderCancelMessageEnabled { get; set; }

        #endregion

        #region Order out of stock

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.OrderOutOfStockMessage, TypeName = "varchar(512)")]
        public string OrderOutOfStockMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.OrderOutOfStockMessageEnabled)]
        public bool OrderOutOfStockMessageEnabled { get; set; }

        #endregion

        #region Order exceed limit

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.OrderExceedLimitMessage, TypeName = "varchar(512)")]
        public string OrderExceedLimitMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.OrderExceedLimitMessageEnabled)]
        public bool OrderExceedLimitMessageEnabled { get; set; }

        #endregion

        #region Booking confirm

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BookingConfirmMessage, TypeName = "varchar(512)")]
        public string BookingConfirmMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BookingConfirmMessageEnabled)]
        public bool BookingConfirmMessageEnabled { get; set; }

        #endregion

        #region Booking cancel

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BookingCancelMessage, TypeName = "varchar(512)")]
        public string BookingCancelMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BookingCancelMessageEnabled)]
        public bool BookingCancelMessageEnabled { get; set; }

        #endregion

        #region Payment receive

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.PaymentReceiveMessage, TypeName = "varchar(512)")]
        public string PaymentReceiveMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.PaymentReceiveMessageEnabled)]
        public bool PaymentReceiveMessageEnabled { get; set; }

        #endregion

        #region Payment accept

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.PaymentAcceptMessage, TypeName = "varchar(512)")]
        public string PaymentAcceptMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.PaymentAcceptMessageEnabled)]
        public bool PaymentAcceptMessageEnabled { get; set; }

        #endregion

        #region Payment reject

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.PaymentRejectMessage, TypeName = "varchar(512)")]
        public string PaymentRejectMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.PaymentRejectMessageEnabled)]
        public bool PaymentRejectMessageEnabled { get; set; }

        #endregion

        #region Delivery address receive

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.DeliveryAddressReceiveMessage, TypeName = "varchar(512)")]
        public string DeliveryAddressReceiveMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.DeliveryAddressReceiveMessageEnabled)]
        public bool DeliveryAddressReceiveMessageEnabled { get; set; }

        #endregion

        #region Delivery address accept

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.DeliveryAddressAcceptMessage, TypeName = "varchar(512)")]
        public string DeliveryAddressAcceptMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.DeliveryAddressAcceptMessageEnabled)]
        public bool DeliveryAddressAcceptMessageEnabled { get; set; }

        #endregion

        #region Delivery address reject

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.DeliveryAddressRejectMessage, TypeName = "varchar(512)")]
        public string DeliveryAddressRejectMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.DeliveryAddressRejectMessageEnabled)]
        public bool DeliveryAddressRejectMessageEnabled { get; set; }

        #endregion

        #region Bill confirm

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BillConfirmMessage, TypeName = "varchar(512)")]
        public string BillConfirmMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BillConfirmMessageEnabled)]
        public bool BillConfirmMessageEnabled { get; set; }

        #endregion

        #region Bill's notify before cancel

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BillNotifyBeforeCancelMessage, TypeName = "varchar(512)")]
        public string BillNotifyBeforeCancelMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BillNotifyBeforeCancelMessageEnabled)]
        public bool BillNotifyBeforeCancelMessageEnabled { get; set; }

        #endregion

        #region Bill cancel

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BillCancelMessage, TypeName = "varchar(512)")]
        public string BillCancelMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BillCancelMessageEnabled)]
        public bool BillCancelMessageEnabled { get; set; }

        #endregion

        #region Bill summary

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.BillSummaryMessage, TypeName = "varchar(512)")]
        public string BillSummaryMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.BillSummaryMessageEnabled)]
        public bool BillSummaryMessageEnabled { get; set; }

        #endregion

        #region Parcel issue

        [Required]
        [MaxLength(512)]
        [Column(Constants.ResponseMessage.Column.ParcelIssueMessage, TypeName = "varchar(512)")]
        public string ParcelIssueMessage { get; set; }

        [Column(Constants.ResponseMessage.Column.ParcelIssueMessageEnabled)]
        public bool ParcelIssueMessageEnabled { get; set; }

        #endregion

        #region Parcel's notify status

        [Column(Constants.ResponseMessage.Column.ParcelNotifyStatusEnabled)]
        public bool ParcelNotifyStatusEnabled { get; set; }

        #endregion

        #region Relationships

        public virtual Status Status { get; set; }

        #endregion
    }
}