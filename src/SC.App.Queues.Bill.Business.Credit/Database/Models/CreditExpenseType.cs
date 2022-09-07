using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Credit.Database.Models
{
    public class CreditExpenseType
    {
        [Key]
        [Column(Constants.CreditExpenseType.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(32)]
        [Column(Constants.CreditExpenseType.Column.Code, TypeName = "varchar(32)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.CreditExpenseType.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.CreditExpenseType.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}