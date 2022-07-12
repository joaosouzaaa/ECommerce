using ECommerce.ShoppingCartServiceAPI.Data.ORM.Context;
using ECommerce.ShoppingCartServiceAPI.Domain.Entities;
using ECommerce.ShoppingCartServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface;
using ECommerce.ShoppingCartServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.ShoppingCartServiceAPI.Data.Repository
{
    public class BaseQueryCommandsRepository<TEntity> : BaseCommandsRepository<TEntity>, IBaseQueryCommandsRepository<int, TEntity>
        where TEntity : BaseEntity
    {
        private readonly IPagingService<TEntity> _pagingService;

        public BaseQueryCommandsRepository(ShoppingCartSqlServerContext context, IPagingService<TEntity> pagingService) : base(context)
        {
            _pagingService = pagingService;
        }

        public async Task<TEntity> FindByAsync(int id, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes) =>
            await IncludeMutiple(_dbSet, asNoTracking, includes).FirstOrDefaultAsync(e => e.Id == id);

        public Task<PageList<TEntity>> FindWithEntitiesPaging(PageParams pageParams, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = IncludeMutiple(_dbSet, asNoTracking, includes);

            return _pagingService.CreatePaginationAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        protected IQueryable<TEntity> IncludeMutiple(IQueryable<TEntity> query, bool asNoTracking, params Expression<Func<TEntity, Object>>[] includes)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (asNoTracking) query = query.AsNoTracking();

            return query;
        }
    }
}
