using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class Billing
    {
        [Key]
        [Column(Constants.Billing.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Billing.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.Billing.Column.IsComplete)]
        public bool IsComplete { get; set; }

        [Column(Constants.Billing.Column.StatusId, TypeName = "varchar(36)")]
        public Guid StatusId { get; set; }

        [Column(Constants.Billing.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Billing.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Billing.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Billing.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [Required]
        [Column(Constants.Billing.Column.BillMessage, TypeName = "mediumtext")]
        public string BillMessage { get; set; }

        [Column(Constants.Billing.Column.CanTransfer)]
        public bool CanTransfer { get; set; }

        [Column(Constants.Billing.Column.CanDeposit)]
        public bool CanDeposit { get; set; }

        [Column(Constants.Billing.Column.DisplayPaymentMethod)]
        public bool DisplayPaymentMethod { get; set; }

        [Column(Constants.Billing.Column.DisplayBankAccount)]
        public bool DisplayBankAccount { get; set; }

        [Column(Constants.Billing.Column.DisplayQrPayment)]
        public bool DisplayQrPayment { get; set; }

        [Column(Constants.Billing.Column.QrPaymentId, TypeName = "varchar(36)")]
        public Guid? QrPaymentId { get; set; }

        [Column(Constants.Billing.Column.CanCod)]
        public bool CanCod { get; set; }

        [Column(Constants.Billing.Column.HasCodAddOn)]
        public bool HasCodAddOn { get; set; }

        [Column(Constants.Billing.Column.CodAddOnAmount, TypeName = "decimal(18, 2)")]
        public decimal? CodAddOnAmount { get; set; }

        [Column(Constants.Billing.Column.CodAddOnPercentage, TypeName = "decimal(18, 2)")]
        public decimal? CodAddOnPercentage { get; set; }

        [Column(Constants.Billing.Column.HasVat)]
        public bool HasVat { get; set; }

        [Column(Constants.Billing.Column.IncludedVat)]
        public bool IncludedVat { get; set; }

        [Column(Constants.Billing.Column.VatPercentage, TypeName = "decimal(18, 2)")]
        public decimal VatPercentage { get; set; }

        [Column(Constants.Billing.Column.BillingTransactionFee, TypeName = "decimal(18, 2)")]
        public decimal BillingTransactionFee { get; set; }

        #region Relationships

        public virtual Status Status { get; set; }

        #endregion
    }
}