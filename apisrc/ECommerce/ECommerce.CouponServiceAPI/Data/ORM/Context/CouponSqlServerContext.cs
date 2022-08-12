using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.CouponServiceAPI.Data.ORM.Context;

public class CouponSqlServerContext : BaseDbContext
{
    public DbSet<Coupon> Coupons { get; set; }

    public CouponSqlServerContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CouponSqlServerContext).Assembly);
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
