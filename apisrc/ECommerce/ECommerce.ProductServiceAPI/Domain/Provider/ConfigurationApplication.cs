using ECommerce.ProductServiceAPI.Domain.Enum;

namespace ECommerce.ProductServiceAPI.Domain.Provider
{
    public class ConfigurationApplication
    {
        public EAmbientTypes Ambient { get; set; }
        public string ConnectionDeveloper { get; set; }
        public string ConnectionProduction { get; set; }
    }
}
