using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Customer.Database.Models
{
    public class Customer
    {
        [Key]
        [Column(Constants.Customer.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Customer.Column.ChannelId, TypeName = "varchar(36)")]
        public Guid ChannelId { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.Customer.Column.Name, TypeName = "varchar(128)")]
        public string Name { get; set; }

        [Column(Constants.Customer.Column.IsNew)]
        public bool IsNew { get; set; }

        [Column(Constants.Customer.Column.IsBlocked)]
        public bool IsBlocked { get; set; }

        [Column(Constants.Customer.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Customer.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        #region Relationships

        public virtual CustomerFacebook CustomerFacebook { get; set; }

        #endregion
    }
}