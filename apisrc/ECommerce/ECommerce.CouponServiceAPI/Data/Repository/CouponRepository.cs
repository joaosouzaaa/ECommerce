using ECommerce.CouponServiceAPI.Data.ORM.Context;
using ECommerce.CouponServiceAPI.Domain.Entities;
using ECommerce.CouponServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.CouponServiceAPI.Data.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponSqlServerContext _dbContext;
        private DbSet<Coupon> _dbSet => _dbContext.Set<Coupon>();

        public CouponRepository(CouponSqlServerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coupon> FindCouponByCode(Expression<Func<Coupon, bool>> where) =>
            await _dbSet.AsNoTracking().FirstOrDefaultAsync(where);
    }
}
