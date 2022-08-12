using ECommerce.CouponServiceAPI.Domain.Entities;
using System.Linq.Expressions;

namespace ECommerce.CouponServiceAPI.Domain.Interface.RepositoryContract;

public interface ICouponRepository
{
    Task<Coupon> FindCouponByCode(Expression<Func<Coupon, bool>> where);
}
