using ECommerce.ProductServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.ProductServiceAPI.Data.ORM.Context;

public class ProductMySqlContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public ProductMySqlContext(DbContextOptions<ProductMySqlContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductMySqlContext).Assembly);
    }

}
