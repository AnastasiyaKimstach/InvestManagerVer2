using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;


namespace InvestManagerVer2.Web.Services
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AssetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAssetAsync(AssetViewModel viewModel)
        {
            var dto = _mapper.Map<Asset>(viewModel);
            await _unitOfWork.Assets.CreateAsync(dto);
        }

        public async Task<AssetViewModel> GetAssetByIdAsync(Guid id)
        {
            var existingAsset = await _unitOfWork.Assets.GetByIdAsync(id);

            if (existingAsset == null)
            {
                var exception = new Exception($"Appartment type with id = {id} was not found");

                throw exception;
            }

            var dto = _mapper.Map<AssetViewModel>(existingAsset);
            return dto;
        }

        public Task<AssetViewModel> GetAssetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
