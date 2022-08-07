using Microsoft.EntityFrameworkCore.Query;
using Moq;

namespace ECommerce.TestProductService.Builders.Util
{
    public class UtilTools
    {
        public static Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> CreareFuncQueryable<TEntity>()
            where TEntity : class
        {
            return It.IsAny<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
        }
    }
}
