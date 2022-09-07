using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class Offering
    {
        [Key]
        [Column(Constants.Offering.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Offering.Column.LiveId, TypeName = "varchar(36)")]
        public Guid LiveId { get; set; }

        [Column(Constants.Offering.Column.ProductId, TypeName = "varchar(36)")]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(64)]
        [Column(Constants.Offering.Column.Code, TypeName = "varchar(64)")]
        public string Code { get; set; }

        [Column(Constants.Offering.Column.Amount)]
        public int Amount { get; set; }

        [Column(Constants.Offering.Column.Price, TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(Constants.Offering.Column.Remaining)]
        public int Remaining { get; set; }

        [Column(Constants.Offering.Column.OfferingStatusId, TypeName = "varchar(36)")]
        public Guid OfferingStatusId { get; set; }

        [Column(Constants.Offering.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Offering.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Offering.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Offering.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        #region Relationships

        public virtual Live Live { get; set; }

        public virtual OfferingStatus OfferingStatus { get; set; }

        #endregion
    }
}