using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManager.ApplicatoinCore.QueryOptions;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CategoryViewModel viewModel)
        {
            var dto = _mapper.Map<Category>(viewModel);
            await _unitOfWork.Categoryes.CreateAsync(dto);
        }

        public async Task DeleteCategoryAsync(CategoryViewModel viewModel)
        {
            var existingCategoryType = await _unitOfWork.Categoryes.GetByIdAsync(viewModel.Id);
            if (existingCategoryType is null)
            {
                var exception = new Exception($"Category {viewModel.CategoryName} was not found");

                throw exception;
            }

            await _unitOfWork.Categoryes.DeleteAsync(existingCategoryType);
        }

        public async Task<List<CategoryViewModel>> GetCategoryAsync()
        {
            var options = new QueryEntityOptions<Category>().AddSortOption(false, x => x.CategoryName);
            var entities = await _unitOfWork.Categoryes.GetAllAsync(options);
            var categoryes = _mapper.Map<List<CategoryViewModel>>(entities);

            return categoryes;
        }
    }
}
