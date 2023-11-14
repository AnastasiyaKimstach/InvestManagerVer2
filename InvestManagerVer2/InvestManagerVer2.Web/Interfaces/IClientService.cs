using InvestManager.ApplicatoinCore.Models;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
}
