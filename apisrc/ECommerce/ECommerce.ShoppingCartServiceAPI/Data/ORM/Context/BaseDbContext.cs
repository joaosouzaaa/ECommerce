using ECommerce.ShoppingCartServiceAPI.Domain.Enum;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;

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
        var connection = new DataConnectionFactory(_configurationApplication).GetConnection();
        var isDevelop = _configurationApplication.Ambient == EAmbientTypes.Development;

        contextOptionsBuilder.UseSqlServer(connection, sql => sql.CommandTimeout(180))
            .EnableSensitiveDataLogging(isDevelop)
            .EnableDetailedErrors(isDevelop);
    }
}
