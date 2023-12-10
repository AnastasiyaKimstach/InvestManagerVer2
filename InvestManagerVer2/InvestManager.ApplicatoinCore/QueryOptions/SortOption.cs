using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.QueryOptions
{
    public class SortOption<TEntity>
    {
        public Expression<Func<TEntity, object>> Expression { get; set; }
        public bool Descending { get; set; }
    }
}
