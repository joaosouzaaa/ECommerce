namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Mapping
{
    public class BaseMapping
    {
        protected string Schema { get; set; }

        public BaseMapping()
        {
            Schema = "DBO";
        }

        public BaseMapping(string schema)
        {
            Schema = schema;
        }
    }
}
