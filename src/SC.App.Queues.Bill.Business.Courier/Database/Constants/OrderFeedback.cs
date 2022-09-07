namespace SC.App.Queues.Bill.Business.Courier.Database.Constants
{
    public class OrderFeedback
    {
        public const string TableName = "order_feedbacks";

        public static class Column
        {
            public const string Id = "id";

            public const string OrderId = "order_id";

            public const string Ref1 = "ref_1";

            public const string Ref2 = "ref_2";

            public const string Ref3 = "ref_3";

            public const string Ref4 = "ref_4";

            public const string Ref5 = "ref_5";

            public const string Width = "width";

            public const string Height = "height";

            public const string Length = "length";

            public const string Weight = "weight";

            public const string Price = "price";

            public const string PriceCalculationTypeId = "price_calculation_type_id";

            public const string CodAmount = "cod_amount";

            public const string CodFee = "cod_fee";

            public const string FreightInsurance = "freight_insurance";

            public const string ValueInsuranceFee = "value_insurance_fee";

            public const string DeclaredValue = "declared_value";

            public const string PackingFee = "packing_fee";

            public const string RemoteAreaFee = "remote_area_fee";

            public const string ExpressTypeId = "express_type_id";

            public const string FreightPrice = "freight_price";

            public const string LabelFee = "label_fee";

            public const string SpeedFee = "speed_fee";
        }
    }
}