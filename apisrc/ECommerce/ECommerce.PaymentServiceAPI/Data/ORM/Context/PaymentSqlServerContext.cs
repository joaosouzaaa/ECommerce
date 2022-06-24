using ECommerce.PaymentServiceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.PaymentServiceAPI.Data.ORM.Context;

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
