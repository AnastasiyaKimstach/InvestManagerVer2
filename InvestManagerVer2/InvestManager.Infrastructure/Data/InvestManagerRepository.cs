using InvestManager.ApplicatoinCore.Models;
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

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
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
