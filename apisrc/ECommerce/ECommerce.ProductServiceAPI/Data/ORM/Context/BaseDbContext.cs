using ECommerce.ProductServiceAPI.Domain.Enum;
using ECommerce.ProductServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.Data.ORM.Context
{
    public class BaseDbContext : DbContext
    {
        private readonly ConfigurationApplication _configurationApplication;

        public BaseDbContext(ConfigurationApplication configurationApplication)
            : base(new DbContextOptions<BaseDbContext>())
        {
            _configurationApplication = configurationApplication;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            var  connection = new DataConnectionFactory(_configurationApplication).GetConnection();

            contextOptionsBuilder.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 28)))
              .EnableSensitiveDataLogging(_configurationApplication.Ambient == EAmbientTypes.Development);
                
        }
    }
}
