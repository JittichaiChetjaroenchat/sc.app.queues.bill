using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Database.Models
{
    public class PaymentVerification
    {
        [Key]
        [Column(Constants.PaymentVerification.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.PaymentVerification.Column.PaymentId, TypeName = "varchar(36)")]
        public Guid PaymentId { get; set; }

        [Column(Constants.PaymentVerification.Column.IsProceed)]
        public bool IsProceed { get; set; }

        [Column(Constants.PaymentVerification.Column.CanVerify)]
        public bool CanVerify { get; set; }

        [Column(Constants.PaymentVerification.Column.IsUnique)]
        public bool IsUnique { get; set; }

        [MaxLength(1024)]
        [Column(Constants.PaymentVerification.Column.DuplicateTo, TypeName = "varchar(1024)")]
        public string DuplicateTo { get; set; }

        [Column(Constants.PaymentVerification.Column.IsCorrectBankAccountNumber)]
        public bool IsCorrectBankAccountNumber { get; set; }

        [Column(Constants.PaymentVerification.Column.IsCorrectBankAccountName)]
        public bool IsCorrectBankAccountName { get; set; }

        [Column(Constants.PaymentVerification.Column.IsCorrectAmount)]
        public bool IsCorrectAmount { get; set; }

        [Column(Constants.PaymentVerification.Column.UnBalanceAmount, TypeName = "decimal(18,2)")]
        public decimal UnBalanceAmount { get; set; }

        [MaxLength(256)]
        [Column(Constants.PaymentVerification.Column.Remark, TypeName = "varchar(256)")]
        public string Remark { get; set; }

        [Column(Constants.PaymentVerification.Column.PaymentVerificationStatusId, TypeName = "varchar(36)")]
        public Guid PaymentVerificationStatusId { get; set; }

        [Column(Constants.PaymentVerification.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        #region Relationships

        public virtual Payment Payment { get; set; }

        public virtual PaymentVerificationDetail PaymentVerificationDetail { get; set; }

        public virtual PaymentVerificationStatus PaymentVerificationStatus { get; set; }

        #endregion
    }
}