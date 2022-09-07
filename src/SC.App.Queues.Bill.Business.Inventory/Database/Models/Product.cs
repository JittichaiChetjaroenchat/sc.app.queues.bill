using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Inventory.Database.Models
{
    public class Product
    {
        [Key]
        [Column(Constants.Product.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.Product.Column.InventoryId, TypeName = "varchar(36)")]
        public Guid InventoryId { get; set; }

        [Column(Constants.Product.Column.ImageId, TypeName = "varchar(36)")]
        public Guid? ImageId { get; set; }

        [Required]
        [MaxLength(16)]
        [Column(Constants.Product.Column.Code, TypeName = "varchar(16)")]
        public string Code { get; set; }

        [Required]
        [MaxLength(32)]
        [Column(Constants.Product.Column.Name, TypeName = "varchar(32)")]
        public string Name { get; set; }

        [MaxLength(128)]
        [Column(Constants.Product.Column.Description, TypeName = "varchar(128)")]
        public string Description { get; set; }

        [MaxLength(32)]
        [Column(Constants.Product.Column.Color, TypeName = "varchar(32)")]
        public string Color { get; set; }

        [MaxLength(32)]
        [Column(Constants.Product.Column.Size, TypeName = "varchar(32)")]
        public string Size { get; set; }

        [Column(Constants.Product.Column.Amount)]
        public int Amount { get; set; }

        [Column(Constants.Product.Column.Cost, TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Column(Constants.Product.Column.Price, TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Column(Constants.Product.Column.StatusId, TypeName = "varchar(36)")]
        public Guid StatusId { get; set; }

        [Column(Constants.Product.Column.CreatedBy, TypeName = "varchar(36)")]
        public Guid CreatedBy { get; set; }

        [Column(Constants.Product.Column.CreatedOn, TypeName = "datetime")]
        public DateTime CreatedOn { get; set; }

        [Column(Constants.Product.Column.UpdatedBy, TypeName = "varchar(36)")]
        public Guid UpdatedBy { get; set; }

        [Column(Constants.Product.Column.UpdatedOn, TypeName = "datetime")]
        public DateTime UpdatedOn { get; set; }

        [MaxLength(16)]
        [Column(Constants.Product.Column.Sku, TypeName = "varchar(16)")]
        public string Sku { get; set; }

        #region Relationships

        public virtual Status Status { get; set; }

        #endregion
    }
}