using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;

public class ShoppingCartContext : BaseDbContext
{
    public ShoppingCartContext(ConfigurationApplication configurationApplication) : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
    }
}
