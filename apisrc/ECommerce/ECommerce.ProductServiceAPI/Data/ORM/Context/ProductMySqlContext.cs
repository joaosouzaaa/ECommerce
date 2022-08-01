using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.Data.ORM.Context;

public class ProductMySqlContext : BaseDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public ProductMySqlContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMySqlContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType()
            .GetProperty("CreateDate") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("CreateDate").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("CreateDate").IsModified = false;
            }
        }

        foreach (var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType()
            .GetProperty("UpdateDate") != null))
        {
            if (entry.State == EntityState.Modified)
            {
                entry.Property("UpdateDate").CurrentValue = DateTime.Now;
            }
        }

        return base.SaveChangesAsync(cancellation);
    }

}
