namespace ECommerce.ProductServiceAPI.Domain.Interface;

public interface IUnitOfWork
{
    void Commit();
    void Rollback();
    void BeginTransaction();
}
