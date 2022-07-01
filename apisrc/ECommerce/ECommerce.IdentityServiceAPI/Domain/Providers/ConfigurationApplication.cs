using ECommerce.ShoppingCartServiceAPI.Domain.Enum;

namespace ECommerce.ShoppingCartServiceAPI.Domain.Providers;

public class ConfigurationApplication
{
    public EAmbientTypes Ambient { get; set; }
    public string ConnectionDeveloper { get; set; }
    public string ConnectionProduction { get; set; }
}
