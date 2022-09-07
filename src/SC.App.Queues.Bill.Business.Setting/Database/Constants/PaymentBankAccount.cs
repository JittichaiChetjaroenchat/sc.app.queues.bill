namespace SC.App.Queues.Bill.Business.Setting.Database.Constants
{
    public class PaymentBankAccount
    {
        public const string TableName = "payment_bank_accounts";

        public static class Column
        {
            public const string Id = "id";

            public const string PaymentId = "payment_id";

            public const string BankId = "bank_id";

            public const string Number = "number";

            public const string Name = "name";

            public const string Branch = "branch";

            public const string Index = "index";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";
        }
    }
}