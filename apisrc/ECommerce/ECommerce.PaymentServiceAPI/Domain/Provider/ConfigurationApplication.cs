using ECommerce.PaymentServiceAPI.Domain.Enum;

namespace ECommerce.PaymentServiceAPI.Domain.Provider
{
    public class ConfigurationApplication
    {
        public EAmbientTypes Ambient { get; set; }
        public string ConnectionDeveloper { get; set; }
        public string ConnectionProduction { get; set; }
    }
}
