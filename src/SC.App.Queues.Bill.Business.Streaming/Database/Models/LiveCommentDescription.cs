using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveCommentDescription
    {
        [Key]
        [Column(Constants.LiveCommentDescription.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.LiveCommentDescription.Column.LiveCommentId, TypeName = "varchar(36)")]
        public Guid LiveCommentId { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsNewCustomer)]
        public bool IsNewCustomer { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsCustomerBlocked)]
        public bool IsCustomerBlocked { get; set; }

        [Column(Constants.LiveCommentDescription.Column.Tags, TypeName = "mediumtext")]
        public string Tags { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsRequestOfferLink)]
        public bool IsRequestOfferLink { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsPurchaseSucceed)]
        public bool IsPurchaseSucceed { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsPurchaseLimitReached)]
        public bool IsPurchaseLimitReached { get; set; }

        [Column(Constants.LiveCommentDescription.Column.HasBill)]
        public bool HasBill { get; set; }

        [Column(Constants.LiveCommentDescription.Column.LatestBillCost)]
        public decimal? LatestBillCost { get; set; }

        [Column(Constants.LiveCommentDescription.Column.LatestBillPaymentId, TypeName = "varchar(36)")]
        public Guid? LatestBillPaymentId { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsLatestBillDeposited)]
        public bool? IsLatestBillDeposited { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsLatestBillPending)]
        public bool? IsLatestBillPending { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsLatestBillNotified)]
        public bool? IsLatestBillNotified { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsLatestBillConfirmed)]
        public bool? IsLatestBillConfirmed { get; set; }

        [Column(Constants.LiveCommentDescription.Column.IsLatestBillCancelled)]
        public bool? IsLatestBillCancelled { get; set; }

        #region Relationships

        public virtual LiveComment LiveComment { get; set; }

        #endregion
    }
}