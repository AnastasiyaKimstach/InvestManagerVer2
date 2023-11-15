using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvestManager.Infrastructure.Data.DBExtentions
{
    public static class TEntityListInclude
    {
        public static IQueryable<TEntity> IncludeFields<TEntity>(this IQueryable<TEntity> entities, IList<Expression<Func<TEntity, object>>> includeOptions) where TEntity : class
        {
            if (includeOptions != null && includeOptions.Count > 0)
            {
                var firstOption = includeOptions.First();
                var query = entities.Include(firstOption);
                foreach (var item in includeOptions.Skip(1))
                {
                    query = query.Include(item);
                }
                return query;
            }
            return entities;
        }
    }
}
