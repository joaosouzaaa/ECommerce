using ECommerce.OrderServiceAPI.Domain.Provider;

namespace ECommerce.OrderServiceAPI.Data.ORM.Context
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
                return _configurationApplication.Ambient == Domain.Enum.EAmbientTypes.Development
                    ? _configurationApplication.ConnectionDeveloper
                    : _configurationApplication.ConnectionProduction;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
