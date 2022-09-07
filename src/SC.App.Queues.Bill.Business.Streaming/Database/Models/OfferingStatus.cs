using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class OfferingStatus
    {
        [Key]
        [Column(Constants.OfferingStatus.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.OfferingStatus.Column.Code, TypeName = "varchar(16)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.OfferingStatus.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.OfferingStatus.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}