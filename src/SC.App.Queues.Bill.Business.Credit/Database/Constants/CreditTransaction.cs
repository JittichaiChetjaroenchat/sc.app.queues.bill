namespace SC.App.Queues.Bill.Business.Credit.Database.Constants
{
    public class CreditTransaction
    {
        public const string TableName = "credit_transactions";

        public static class Column
        {
            public const string Id = "id";

            public const string CreditId = "credit_id";

            public const string CreditExpenseTypeId = "credit_expense_type_id";

            public const string Amount = "amount";

            public const string Remark = "remark";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";
        }
    }
}