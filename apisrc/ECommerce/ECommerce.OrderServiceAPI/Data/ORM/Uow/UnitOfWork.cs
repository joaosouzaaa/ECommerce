using ECommerce.OrderServiceAPI.Data.ORM.Context;
using ECommerce.OrderServiceAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ECommerce.OrderServiceAPI.Data.ORM.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseFacade _database;

        public UnitOfWork(OrderSqlServerlContext context)
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
