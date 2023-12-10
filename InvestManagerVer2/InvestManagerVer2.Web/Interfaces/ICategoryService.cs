using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CategoryViewModel viewModel);
        Task DeleteCategoryAsync(CategoryViewModel viewModel);
        Task<List<CategoryViewModel>> GetCategoryAsync();
    }
}
