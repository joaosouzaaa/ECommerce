using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;

public class ShoppingCartSqlServerContext : BaseDbContext
{

    public ShoppingCartSqlServerContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartSqlServerContext).Assembly);
    }

}
