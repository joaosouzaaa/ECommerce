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

    public ShoppingCartContext(ConfigurationApplication configurationApplication) 
        : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingCartContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType()
            .GetProperty("CreateDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdateDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellation);
    }
}
