using InvestManager.ApplicatoinCore.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
    }
}
