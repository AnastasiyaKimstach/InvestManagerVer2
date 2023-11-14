using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;

namespace InvestManagerVer2.Web.Servisces
{
    public class ClientService : IClientService
    {
        private readonly IRepository _clientRepository;
        public ClientService(IRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientRepository.GetClientsAsync();
        }
    }
}
