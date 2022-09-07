using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Courier.Database.Models
{
    public class OrderManifest
    {
        [Key]
        [Column(Constants.OrderManifest.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.OrderManifest.Column.OrderId, TypeName = "varchar(36)")]
        public Guid OrderId { get; set; }

        [Required]
        [MaxLength(32)]
        [Column(Constants.OrderManifest.Column.ShopId, TypeName = "varchar(32)")]
        public string ShopId { get; set; }

        [Column(Constants.OrderManifest.Column.CourierId, TypeName = "varchar(36)")]
        public Guid CourierId { get; set; }

        [Column(Constants.OrderManifest.Column.OrderOwnershipTypeId, TypeName = "varchar(36)")]
        public Guid OrderOwnershipTypeId { get; set; }

        [Column(Constants.OrderManifest.Column.OrderShippingTypeId, TypeName = "varchar(36)")]
        public Guid OrderShippingTypeId { get; set; }

        [Column(Constants.OrderManifest.Column.OrderVelocityTypeId, TypeName = "varchar(36)")]
        public Guid OrderVelocityTypeId { get; set; }

        [Column(Constants.OrderManifest.Column.OrderPaymentTypeId, TypeName = "varchar(36)")]
        public Guid OrderPaymentTypeId { get; set; }

        [Column(Constants.OrderManifest.Column.CodAmount, TypeName = "decimal(18, 2)")]
        public decimal CodAmount { get; set; }

        [Column(Constants.OrderManifest.Column.OrderInsuranceTypeId, TypeName = "varchar(36)")]
        public Guid OrderInsuranceTypeId { get; set; }

        [Column(Constants.OrderManifest.Column.InsuranceAmount, TypeName = "decimal(18, 2)")]
        public decimal InsuranceAmount { get; set; }

        [Column(Constants.OrderManifest.Column.InCreditRedeemed)]
        public bool InCreditRedeemed { get; set; }

        [Column(Constants.OrderManifest.Column.Weight, TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }

        [Column(Constants.OrderManifest.Column.Width, TypeName = "decimal(18, 2)")]
        public decimal? Width { get; set; }

        [Column(Constants.OrderManifest.Column.Length, TypeName = "decimal(18, 2)")]
        public decimal? Length { get; set; }

        [Column(Constants.OrderManifest.Column.Height, TypeName = "decimal(18, 2)")]
        public decimal? Height { get; set; }

        [Column(Constants.OrderManifest.Column.Cost, TypeName = "decimal(18, 2)")]
        public decimal Cost { get; set; }

        #region Relationships

        public virtual Order Order { get; set; }

        public virtual Courier Courier { get; set; }

        #endregion
    }
}