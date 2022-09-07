using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Setting.Database.Models
{
    public class Status
    {
        [Key]
        [Column(Constants.Status.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.Status.Column.Code, TypeName = "varchar(8)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.Status.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.Status.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}