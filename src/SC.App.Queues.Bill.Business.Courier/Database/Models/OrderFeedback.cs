using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.App.Queues.Bill.Business.Courier.Database.Models
{
    public class OrderFeedback
    {
        [Key]
        [Column(Constants.OrderFeedback.Column.Id, TypeName = "varchar(36)")]
        public Guid Id { get; set; }

        [Column(Constants.OrderFeedback.Column.OrderId, TypeName = "varchar(36)")]
        public Guid OrderId { get; set; }

        [MaxLength(128)]
        [Column(Constants.OrderFeedback.Column.Ref1, TypeName = "varchar(128)")]
        public string Ref1 { get; set; }

        [MaxLength(128)]
        [Column(Constants.OrderFeedback.Column.Ref2, TypeName = "varchar(128)")]
        public string Ref2 { get; set; }

        [MaxLength(128)]
        [Column(Constants.OrderFeedback.Column.Ref3, TypeName = "varchar(128)")]
        public string Ref3 { get; set; }

        [MaxLength(128)]
        [Column(Constants.OrderFeedback.Column.Ref4, TypeName = "varchar(128)")]
        public string Ref4 { get; set; }

        [MaxLength(128)]
        [Column(Constants.OrderFeedback.Column.Ref5, TypeName = "varchar(128)")]
        public string Ref5 { get; set; }

        [Column(Constants.OrderFeedback.Column.Width, TypeName = "decimal(18, 2)")]
        public decimal? Width { get; set; }

        [Column(Constants.OrderFeedback.Column.Height, TypeName = "decimal(18, 2)")]
        public decimal? Height { get; set; }

        [Column(Constants.OrderFeedback.Column.Length, TypeName = "decimal(18, 2)")]
        public decimal? Length { get; set; }

        [Column(Constants.OrderFeedback.Column.Weight, TypeName = "decimal(18, 2)")]
        public decimal? Weight { get; set; }

        [Column(Constants.OrderFeedback.Column.Price, TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        [Column(Constants.OrderFeedback.Column.PriceCalculationTypeId, TypeName = "varchar(36)")]
        public Guid? PriceCalculationTypeId { get; set; }

        [Column(Constants.OrderFeedback.Column.CodAmount, TypeName = "decimal(18, 2)")]
        public decimal? CodAmount { get; set; }

        [Column(Constants.OrderFeedback.Column.CodFee, TypeName = "decimal(18, 2)")]
        public decimal? CodFee { get; set; }

        [Column(Constants.OrderFeedback.Column.FreightInsurance, TypeName = "decimal(18, 2)")]
        public decimal? FreightInsurance { get; set; }

        [Column(Constants.OrderFeedback.Column.ValueInsuranceFee, TypeName = "decimal(18, 2)")]
        public decimal? ValueInsuranceFee { get; set; }

        [Column(Constants.OrderFeedback.Column.DeclaredValue, TypeName = "decimal(18, 2)")]
        public decimal? DeclaredValue { get; set; }

        [Column(Constants.OrderFeedback.Column.PackingFee, TypeName = "decimal(18, 2)")]
        public decimal? PackingFee { get; set; }

        [Column(Constants.OrderFeedback.Column.RemoteAreaFee, TypeName = "decimal(18, 2)")]
        public decimal? RemoteAreaFee { get; set; }

        [Column(Constants.OrderFeedback.Column.ExpressTypeId, TypeName = "varchar(36)")]
        public Guid? ExpressTypeId { get; set; }

        [Column(Constants.OrderFeedback.Column.FreightPrice, TypeName = "decimal(18, 2)")]
        public decimal? FreightPrice { get; set; }

        [Column(Constants.OrderFeedback.Column.LabelFee, TypeName = "decimal(18, 2)")]
        public decimal? LabelFee { get; set; }

        [Column(Constants.OrderFeedback.Column.SpeedFee, TypeName = "decimal(18, 2)")]
        public decimal? SpeedFee { get; set; }

        #region Relationships

        public virtual Order Order { get; set; }

        #endregion
    }
}