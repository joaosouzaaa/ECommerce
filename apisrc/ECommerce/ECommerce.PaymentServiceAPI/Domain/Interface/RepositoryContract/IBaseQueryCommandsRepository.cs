﻿using ECommerce.PaymentServiceAPI.Domain.Handlers.Pagination;
using System.Linq.Expressions;

namespace ECommerce.PaymentServiceAPI.Domain.Interface.RepositoryContract;

public interface IBaseQueryCommandsRepository<TKey, TEntity>
    where TEntity : class
{
    Task<TEntity> FindByAsync(TKey id, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes);
    Task<PageList<TEntity>> FindWithEntitiesPaging(PageParams pageParams, bool asNoTracking = false, params Expression<Func<TEntity, object>>[] includes);
}
