using InvestManager.ApplicatoinCore.Models;
using InvestManager.ApplicatoinCore.QueryOptions;
using System.Linq.Expressions;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //Task<IList<T>> GetAllAsync(QueryEntityOptions<T> options); 
        Task<IList<T>> GetAllAsync(QueryEntityOptions<T> options);
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
