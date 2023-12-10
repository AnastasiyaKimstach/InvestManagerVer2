using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.QueryOptions
{
    public sealed class QueryEntityOptions<TEntity> : BaseQueryOptions<TEntity> where TEntity : class
    {
        private IList<Expression<Func<TEntity, object>>> _includeOptions;

        public string SqlQuery { get; private set; }
        public IList<Expression<Func<TEntity, object>>> IncludeOptions { get { return _includeOptions; } }

        public QueryEntityOptions<TEntity> AddSqlQuery(string sqlQuery)
        {
            SqlQuery = sqlQuery;
            return this;
        }

        public QueryEntityOptions<TEntity> SetFilterOption(Expression<Func<TEntity, bool>> filterOption)
        {
            _filterOption = filterOption;
            return this;
        }

        public QueryEntityOptions<TEntity> AddSortOption(bool descending, Expression<Func<TEntity, object>> sortOption)
        {
            _sortOptions = _sortOptions ?? new List<SortOption<TEntity>>();
            _sortOptions.Add(new SortOption<TEntity>() { Descending = descending, Expression = sortOption });
            return this;
        }
    }
}
