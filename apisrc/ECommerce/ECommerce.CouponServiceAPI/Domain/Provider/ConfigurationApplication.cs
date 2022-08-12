using ECommerce.CouponServiceAPI.Domain.Enum;

namespace ECommerce.CouponServiceAPI.Domain.Provider
{
    public class ConfigurationApplication
    {
        public EAmbientTypes Ambient { get; set; }
        public string ConnectionDeveloper { get; set; }
        public string ConnectionProduction { get; set; }
    }
}
