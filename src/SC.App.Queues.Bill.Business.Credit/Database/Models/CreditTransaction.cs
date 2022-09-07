using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Credit.Database.Models
{
    public class CreditTransaction
    {
        [Key]
        [Column(Constants.CreditTransaction.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.CreditTransaction.Column.CreditId, TypeName = "varchar(36)")]
        public Guid CreditId { get; set; }

        [Column(Constants.CreditTransaction.Column.CreditExpenseTypeId, TypeName = "varchar(36)")]
        public Guid CreditExpenseTypeId { get; set; }

        [Column(Constants.CreditTransaction.Column.Amount, TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(1024)]
        [Column(Constants.CreditTransaction.Column.Remark, TypeName = "varchar(1024)")]
        public string Remark { get; set; }

        [Column(Constants.CreditTransaction.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.CreditTransaction.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        #region Relationships

        public virtual Credit Credit { get; set; }

        public virtual CreditExpenseType CreditExpenseType { get; set; }

        #endregion
    }
}