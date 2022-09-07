using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Credit.Database.Models
{
    public class Credit
    {
        [Key]
        [Column(Constants.Credit.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Credit.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Column(Constants.Credit.Column.Balance, TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        [Column(Constants.Credit.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Credit.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Credit.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Credit.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        #region Relationships

        public virtual ICollection<CreditTransaction> CreditTransactions { get; set; }

        #endregion
    }
}