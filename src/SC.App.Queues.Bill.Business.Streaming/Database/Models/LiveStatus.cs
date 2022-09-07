using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Streaming.Database.Models
{
    public class LiveStatus
    {
        [Key]
        [Column(Constants.LiveStatus.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.LiveStatus.Column.Code, TypeName = "varchar(16)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.LiveStatus.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [Column(Constants.LiveStatus.Column.Index)]
        public int Index { get; set; }

        #region Relationships

        #endregion
    }
}