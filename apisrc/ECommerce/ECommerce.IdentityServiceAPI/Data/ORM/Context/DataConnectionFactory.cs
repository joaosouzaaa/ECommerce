using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Providers;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context
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
