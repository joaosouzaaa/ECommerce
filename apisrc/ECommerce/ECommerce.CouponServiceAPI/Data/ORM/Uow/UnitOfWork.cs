using ECommerce.CouponServiceAPI.Data.ORM.Context;
using ECommerce.CouponServiceAPI.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ECommerce.CouponServiceAPI.Data.ORM.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseFacade _database;

        public UnitOfWork(CouponSqlServerContext context)
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
