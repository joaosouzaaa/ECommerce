using ECommerce.IdentityServiceAPI.Domain.Enum;
using ECommerce.IdentityServiceAPI.Domain.Providers;

namespace ECommerce.IdentityServiceAPI.Data.ORM.Context
{
    public class DataConnectionFactory
    {

        private readonly ConfigurationApplication _configurationApplication;

        public DataConnectionFactory(ConfigurationApplication configurationApplication)
        {
            _configurationApplication = configurationApplication;
        }

        public string GetConnection()
        {
            try
            {
                return _configurationApplication.Ambient == EAmbientTypes.Development 
                    ? _configurationApplication.ConnectionDeveloper
                    : _configurationApplication.ConnectionProduction;
                    
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
