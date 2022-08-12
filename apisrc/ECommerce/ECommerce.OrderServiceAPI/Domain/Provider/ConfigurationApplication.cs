using ECommerce.OrderServiceAPI.Domain.Enum;

namespace ECommerce.OrderServiceAPI.Domain.Provider
{
    public class ConfigurationApplication
    {
        public EAmbientTypes Ambient { get; set; }
        public string ConnectionDeveloper { get; set; }
        public string ConnectionProduction { get; set; }
    }
}
