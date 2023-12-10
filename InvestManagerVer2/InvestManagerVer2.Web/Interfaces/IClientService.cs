using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

public interface IClientService
{
    public Task<RegisterViewModel> Register(RegisterViewModel model);

    public Task<LoginViewModel> Login(LoginViewModel model);
}
