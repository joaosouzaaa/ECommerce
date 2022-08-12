using ECommerce.OrderServiceAPI.Domain.Enum;
using ECommerce.OrderServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.OrderServiceAPI.Data.ORM.Context
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

            contextOptionsBuilder.UseSqlServer(connection, sql => sql.CommandTimeout(180))
              .EnableSensitiveDataLogging(_configurationApplication.Ambient == EAmbientTypes.Development);
                
        }
    }
}
