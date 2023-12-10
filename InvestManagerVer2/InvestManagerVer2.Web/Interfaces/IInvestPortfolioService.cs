using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IInvestPortfolioService
    {
        Task CreateInvestPortfolioAsync(InvestPortfolioViewModel viewModel);
        Task DeleteInvestPortfolioAsync(InvestPortfolioViewModel viewModel);
    }
}
