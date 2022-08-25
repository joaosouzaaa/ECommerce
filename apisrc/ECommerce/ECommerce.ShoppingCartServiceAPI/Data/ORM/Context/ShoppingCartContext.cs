using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;

public class ShoppingCartContext : BaseDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<ShoppingCartHeader> ShoppingCarts { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<CardPayment> CardPayments { get; set; }

    public ShoppingCartContext(ConfigurationApplication configurationApplication) : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
    }
}
