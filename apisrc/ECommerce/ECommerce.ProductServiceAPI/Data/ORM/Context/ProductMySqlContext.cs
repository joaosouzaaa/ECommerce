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

}
