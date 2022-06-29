using ECommerce.PaymentServiceAPI.Domain.Enum;
using ECommerce.PaymentServiceAPI.Domain.Provider;

namespace ECommerce.PaymentServiceAPI.Data.ORM.Context
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
