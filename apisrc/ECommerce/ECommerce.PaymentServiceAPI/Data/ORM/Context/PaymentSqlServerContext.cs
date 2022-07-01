using ECommerce.PaymentServiceAPI.Data.ORM.Context;
using ECommerce.PaymentServiceAPI.Domain.Provider;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.PaymentServiceAPI.Data.ORM.Context;

public class PaymentSqlServerContext : BaseDbContext
{

    public PaymentSqlServerContext(ConfigurationApplication configurationApplication)
        : base(configurationApplication)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentSqlServerContext).Assembly);
    }

}
