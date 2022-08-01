using System.Text.Json.Serialization;

namespace ECommerce.ProductServiceAPI.Settings;

public static class ControllersConfiguration
{
    public static void AddControllersConfiguration(this IServiceCollection services)
    {
        services.AddControllers()
            .AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
    }
}
