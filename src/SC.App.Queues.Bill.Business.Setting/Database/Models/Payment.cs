using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class Payment
    {
        [Key]
        [Column(Constants.Payment.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Payment.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.Payment.Column.IsComplete)]
        public bool IsComplete { get; set; }

        [Column(Constants.Payment.Column.StatusId, TypeName = "varchar(36)")]
        public Guid StatusId { get; set; }

        [Column(Constants.Payment.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Payment.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Payment.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Payment.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [Column(Constants.Payment.Column.IsVerifySlipAutomatic)]
        public bool IsVerifySlipAutomatic { get; set; }

        [Column(Constants.Payment.Column.IsConfirmBillAutomatic)]
        public bool IsConfirmBillAutomatic { get; set; }

        [Column(Constants.Payment.Column.VerifySlipTransactionFee, TypeName = "decimal(18, 2)")]
        public decimal VerifySlipTransactionFee { get; set; }

        #region Relationships

        public virtual ICollection<PaymentBankAccount> PaymentBankAccounts { get; set; }

        public virtual Status Status { get; set; }

        #endregion
    }
}