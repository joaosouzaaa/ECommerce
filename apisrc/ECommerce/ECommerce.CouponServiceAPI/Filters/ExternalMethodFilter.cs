namespace ECommerce.CouponServiceAPI.Filters;

public static class ExternalMethodFilter
{
    public static bool IsMethodGet(dynamic context) => context.HttpContext.Request.Method == "GET";      
}
