

using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Services
{
    public class AssetInPortfolioService : IAssetInPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssetInPortfolioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAssetInPortfolioAsync(AssetInPortfolioViewModel viewModel)
        {
            var dto = _mapper.Map<AssetInPortfolio>(viewModel);
            await _unitOfWork.AssetInPortfolioes.CreateAsync(dto);
        }

        public async Task DeleteAssetInPortfolioAsync(AssetInPortfolioViewModel viewModel)
        {
            var existingAssetInPortfolio = await _unitOfWork.AssetInPortfolioes.GetByIdAsync(viewModel.Id);
            if (existingAssetInPortfolio is null)
            {
                var exception = new Exception($"AssetInPortfolio with id = {viewModel.Id} was not found");

                throw exception;
            }

            await _unitOfWork.AssetInPortfolioes.DeleteAsync(existingAssetInPortfolio);
        }

        public async Task<AssetInPortfolioViewModel> GetAssetInPortfolioViewModelByIdAsync(Guid id)
        {
            var existingAssetInPortfolio = await _unitOfWork.AssetInPortfolioes.GetByIdAsync(id);

            if (existingAssetInPortfolio == null)
            {
                var exception = new Exception($"AssetInPortfolio type with id = {id} was not found");

                throw exception;
            }

            var dto = _mapper.Map<AssetInPortfolioViewModel>(existingAssetInPortfolio);

            return dto;
        }
    }
}
