using ECommerce.IdentityServiceAPI.Domain.Enum;

namespace ECommerce.IdentityServiceAPI.Domain.Providers;

public class ConfigurationApplication
{
    public EAmbientTypes Ambient { get; set; }
    public string ConnectionDeveloper { get; set; }
    public string ConnectionProduction { get; set; }
}
