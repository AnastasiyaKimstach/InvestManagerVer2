using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IAssetInPortfolioService
    {
        Task CreateAssetInPortfolioAsync(AssetInPortfolioViewModel viewModel);
        Task DeleteAssetInPortfolioAsync(AssetInPortfolioViewModel viewModel);

        Task<AssetInPortfolioViewModel> GetAssetInPortfolioViewModelByIdAsync(Guid id);
    }
}
