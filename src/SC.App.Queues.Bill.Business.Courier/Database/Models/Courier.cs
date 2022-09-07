using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Courier.Database.Models
{
    public class Courier
    {
        [Key]
        [Column(Constants.Courier.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(8)]
        [Column(Constants.Courier.Column.Code, TypeName = "varchar(8)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.Courier.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.Courier.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}