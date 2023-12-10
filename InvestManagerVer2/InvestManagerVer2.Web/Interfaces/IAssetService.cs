using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface IAssetService
    {
        Task CreateAssetAsync(AssetViewModel viewModel);

        Task<AssetViewModel> GetAssetByIdAsync(int id);
    }
}
