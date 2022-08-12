namespace ECommerce.OrderServiceAPI.Domain.Interface;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction();
}
