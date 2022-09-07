using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Area.Database.Models
{
    public class Area
    {
        [Key]
        [Column(Constants.Area.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Area.Column.RegionId, TypeName = "varchar(36)")]
        public Guid RegionId { get; set; }

        [Required]
        [MaxLength(64)]
        [Column(Constants.Area.Column.Province, TypeName = "varchar(64)")]
        public string Province { get; set; }

        [Required]
        [MaxLength(64)]
        [Column(Constants.Area.Column.District, TypeName = "varchar(64)")]
        public string District { get; set; }

        [Required]
        [MaxLength(64)]
        [Column(Constants.Area.Column.SubDistrict, TypeName = "varchar(64)")]
        public string SubDistrict { get; set; }

        [Required]
        [MaxLength(8)]
        [Column(Constants.Area.Column.PostalCode, TypeName = "varchar(8)")]
        public string PostalCode { get; set; }

        [Column(Constants.Area.Column.IsCapital)]
        public bool IsCapital { get; set; }

        [Column(Constants.Area.Column.IsPerimeter)]
        public bool IsPerimeter { get; set; }

        #region Relationships

        #endregion
    }
}