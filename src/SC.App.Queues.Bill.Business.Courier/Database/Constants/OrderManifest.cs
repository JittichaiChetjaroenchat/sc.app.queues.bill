namespace SC.App.Queues.Bill.Business.Courier.Database.Constants
{
    public class OrderManifest
    {
        public const string TableName = "order_manifests";

        public static class Column
        {
            public const string Id = "id";

            public const string OrderId = "order_id";

            public const string ShopId = "shop_id";

            public const string CourierId = "courier_id";

            public const string OrderOwnershipTypeId = "order_ownership_type_id";

            public const string OrderShippingTypeId = "order_shipping_type_id";

            public const string OrderVelocityTypeId = "order_velocity_type_id";

            public const string OrderPaymentTypeId = "order_payment_type_id";

            public const string CodAmount = "cod_amount";

            public const string OrderInsuranceTypeId = "order_insurance_type_id";

            public const string InsuranceAmount = "insuranse_amount";

            public const string InCreditRedeemed = "is_credit_redeemed";

            public const string Weight = "weight";

            public const string Width = "width";

            public const string Length = "length";

            public const string Height = "height";

            public const string Cost = "cost";
        }
    }
}