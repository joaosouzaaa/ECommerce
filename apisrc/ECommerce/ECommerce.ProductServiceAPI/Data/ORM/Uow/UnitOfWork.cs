using ECommerce.ProductServiceAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ECommerce.ProductServiceAPI.Data.ORM.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseFacade _database;

        public UnitOfWork(DbContext context)
        {
            this._database = context.Database;
        }

        public void BeginTransaction() => this._database.BeginTransaction();
        public void Rollback() => this._database.RollbackTransaction();


        public void Commit()
        {
            try
            {
                this._database.CommitTransaction();
            }
            catch
            {
                this._database.RollbackTransaction();
                throw;
            }
        }
    }
}
