using InvestManager.ApplicatoinCore.Models;
using InvestManager.Infrastructure.Data;
using InvestManagerVer2.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InvestManagerVer2.Web.Repositories
{
    public class ClientRepository : IRepository
    {
        private readonly InvestManagerContext _dbContext;
        public ClientRepository(InvestManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _dbContext.Clients.ToListAsync();
        }
    }
}
