using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class PaymentBankAccount
    {
        [Key]
        [Column(Constants.PaymentBankAccount.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.PaymentBankAccount.Column.PaymentId, TypeName = "varchar(36)")]
        public Guid PaymentId { get; set; }

        [Column(Constants.PaymentBankAccount.Column.BankId, TypeName = "varchar(36)")]
        public Guid BankId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column(Constants.PaymentBankAccount.Column.Number, TypeName = "varchar(32)")]
        public string Number { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.PaymentBankAccount.Column.Name, TypeName = "varchar(128)")]
        public string Name { get; set; }

        [MaxLength(128)]
        [Column(Constants.PaymentBankAccount.Column.Branch, TypeName = "varchar(128)")]
        public string Branch { get; set; }

        [Column(Constants.PaymentBankAccount.Column.Index)]
        public int Index { get; set; }

        [Column(Constants.PaymentBankAccount.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.PaymentBankAccount.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.PaymentBankAccount.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.PaymentBankAccount.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        #region Relationships

        #endregion
    }
}