namespace ECommerce.CouponServiceAPI.Domain.Interface;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction();
}
