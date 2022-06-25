using ECommerce.IdentityServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.IdentityServiceAPI.Data.ORM.Context;

public class PaymentSqlServerContext : DbContext
{

    public PaymentSqlServerContext(DbContextOptions<PaymentSqlServerContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentSqlServerContext).Assembly);
    }

}
