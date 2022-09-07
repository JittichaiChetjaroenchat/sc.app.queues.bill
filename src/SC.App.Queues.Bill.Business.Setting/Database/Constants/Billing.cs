namespace SC.App.Queues.Bill.Business.Setting.Database.Constants
{
    public class Billing
    {
        public const string TableName = "billings";

        public static class Column
        {
            public const string Id = "id";

            public const string ChannelId = "channel_id";

            public const string IsComplete = "is_complete";

            public const string StatusId = "status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";

            public const string BillMessage = "bill_message";

            public const string CanTransfer = "can_transfer";

            public const string CanDeposit = "can_deposit";

            public const string DisplayPaymentMethod = "display_payment_method";

            public const string DisplayBankAccount = "display_bank_account";

            public const string DisplayQrPayment = "display_qr_payment";

            public const string QrPaymentId = "qr_payment_id";

            public const string CanCod = "can_cod";

            public const string HasCodAddOn = "has_cod_addon";

            public const string CodAddOnAmount = "cod_addon_amount";

            public const string CodAddOnPercentage = "cod_addon_percentage";

            public const string HasVat = "has_vat";

            public const string IncludedVat = "included_vat";

            public const string VatPercentage = "vat_percentage";

            public const string BillingTransactionFee = "billing_transaction_fee";
        }
    }
}