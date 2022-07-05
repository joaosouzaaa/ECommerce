using ECommerce.IdentityServiceAPI.Domain.Providers;
using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.IdentityServiceAPI.Ioc.DIServices;

public static class IdentityDIConfiguration
{
    public static void AddIdentityDIConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<IdentitySqlServerContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
            options.EmitStaticAudienceClaim = true;
        })
        .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
        .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
        .AddInMemoryClients(IdentityConfiguration.Clients)
        ;
    }
}
