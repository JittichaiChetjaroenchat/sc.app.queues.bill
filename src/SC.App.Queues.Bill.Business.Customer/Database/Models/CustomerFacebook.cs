using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Customer.Database.Models
{
    public class CustomerFacebook
    {
        [Key]
        [Column(Constants.CustomerFacebook.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.CustomerFacebook.Column.CustomerId, TypeName = "varchar(36)")]
        public Guid CustomerId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column(Constants.CustomerFacebook.Column.FacebookId, TypeName = "varchar(32)")]
        public string FacebookId { get; set; }

        [Required]
        [MaxLength(128)]
        [Column(Constants.CustomerFacebook.Column.FacebookName, TypeName = "varchar(128)")]
        public string FacebookName { get; set; }

        #region Relationships

        public virtual Customer Customer { get; set; }

        #endregion
    }
}