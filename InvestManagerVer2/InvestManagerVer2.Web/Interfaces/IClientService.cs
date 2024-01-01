using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

public interface IClientService
{
    public Task<RegisterViewModel> Register(RegisterViewModel model);

    public Task<LoginViewModel> Login(LoginViewModel model);
    Task<List<RegisterViewModel>> GetClientAsync();
    Task<RegisterViewModel> GetClientViewModelByIdAsync(Guid id);
    Task UpdateClientAsync(RegisterViewModel viewModel);

}
