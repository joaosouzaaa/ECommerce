using ECommerce.OrderServiceAPI.Domain.Entities;
using ECommerce.OrderServiceAPI.Domain.Provider;
using ECommerce.OrderServiceAPI.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.OrderServiceAPI.Data.ORM.Context;

public class OrderSqlServerContext : BaseDbContext
{
    public DbSet<Product> OrderDetails { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }

    public OrderSqlServerContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderSqlServerContext).Assembly);
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
