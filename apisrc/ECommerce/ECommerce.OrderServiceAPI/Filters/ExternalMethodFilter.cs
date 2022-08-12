namespace ECommerce.OrderServiceAPI.Filters;

public static class ExternalMethodFilter
{
    public static bool IsMethodGet(dynamic context) => context.HttpContext.Request.Method == "GET";      
}
