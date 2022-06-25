using ECommerce.IdentityServiceAPI.Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServiceAPI.Data.ORM.Context;

public class IdentitySqlServerContext : BaseDbContext
{

    public IdentitySqlServerContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentitySqlServerContext).Assembly);
    }

}
