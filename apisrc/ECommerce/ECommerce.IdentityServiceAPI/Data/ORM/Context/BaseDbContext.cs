using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Providers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context
{
    public class BaseDbContext : IdentityDbContext<User>
    {
        private readonly ConfigurationApplication _configurationApplication;

        public BaseDbContext(ConfigurationApplication configurationApplication)
            : base(new DbContextOptions<BaseDbContext>())
        {
            _configurationApplication = configurationApplication;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {

            var connection = new DataConnectionFactory(_configurationApplication).GetConnection();

            contextOptionsBuilder.UseSqlServer(connection, sql => sql.CommandTimeout(180))
                                 .EnableSensitiveDataLogging(_configurationApplication.Ambient == EAmbientTypes.Development);
        }
    }
}
