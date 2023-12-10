using InvestManager.ApplicatoinCore.Models;
using InvestManager.ApplicatoinCore.QueryOptions;
using InvestManager.Infrastructure.Data;
using InvestManager.Infrastructure.Data.DBExtentions;
using InvestManagerVer2.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvestManagerVer2.Web.Repositories
{
    public class InvestManagerRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly InvestManagerContext _dbContext;

        public InvestManagerRepository(InvestManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync(QueryEntityOptions<T> options)
        {
            return await _dbContext.Set<T>()
                                            .FromSqlQquery(options.SqlQuery)
                                            .IncludeFields(options.IncludeOptions)
                                            .FilterEntities(options.FilterOption)
                                            .OrderEntityBy(options.SortOptions)
                                            .SkipTakeEntities(options.PageOptions.CurrentPage, options.PageOptions.PageSize)
                                            .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
        {
            var entities = await _dbContext.Set<T>().IncludeFields(includes).FirstOrDefaultAsync(x => x.Id == x.Id);
            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
