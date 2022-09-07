namespace SC.App.Queues.Bill.Business.Inventory.Database.Constants
{
    public class Product
    {
        public const string TableName = "products";

        public static class Column
        {
            public const string Id = "id";

            public const string InventoryId = "inventory_id";

            public const string ImageId = "image_id";

            public const string Code = "code";

            public const string Name = "name";

            public const string Description = "description";

            public const string Color = "color";

            public const string Size = "size";

            public const string Amount = "amount";

            public const string Cost = "cost";

            public const string Price = "price";

            public const string StatusId = "status_id";

            public const string CreatedBy = "created_by";

            public const string CreatedOn = "created_on";

            public const string UpdatedBy = "updated_by";

            public const string UpdatedOn = "updated_on";

            public const string Sku = "sku";
        }
    }
}