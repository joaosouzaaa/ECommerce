using ECommerce.ProductServiceAPI.Data.ORM.Context;
using ECommerce.ProductServiceAPI.Domain.Entities;
using ECommerce.ProductServiceAPI.Domain.Handlers.Pagination;
using ECommerce.ProductServiceAPI.Domain.Interface;
using ECommerce.ProductServiceAPI.Domain.Interface.RepositoryContract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.ProductServiceAPI.Data.Repository;

public class BaseQueryCommandsRepository<TEntity> : BaseCommandsRepository<TEntity> ,IBaseQueryCommandsRepository<int, TEntity>
    where TEntity : BaseEntity
{
    private readonly IPagingService<TEntity> _pagingService;

    public BaseQueryCommandsRepository(ProductMySqlContext context) : base(context)
    {
    }

    public async Task<TEntity> FindByAsync(int id, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes) =>
        await IncludeMultiple(_dbSet, asNoTracking, includes).FirstOrDefaultAsync(e => e.Id == id);
   

    public async Task<PageList<TEntity>> FindWithEntitiesPaging(PageParams pageParams, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes)
    {
        var query =  IncludeMultiple(_dbSet, asNoTracking, includes);

        return await _pagingService.CreatePaginationAsync(query, pageParams.PageNumber, pageParams.PageSize);
    }

    protected IQueryable<TEntity> IncludeMultiple(IQueryable<TEntity> query, bool asNoTrack, params Expression<Func<TEntity, object>>[] includes)
    {
        query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (asNoTrack) query = query.AsNoTracking();

        return query;
    }  
}
