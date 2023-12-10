using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Services
{
    public class InvestPortfolioService : IInvestPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InvestPortfolioService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateInvestPortfolioAsync(InvestPortfolioViewModel viewModel)
        {
            var dto = _mapper.Map<InvestPortfolio>(viewModel);
            await _unitOfWork.InvestPortfolioes.CreateAsync(dto);
        }

        public async Task DeleteInvestPortfolioAsync(InvestPortfolioViewModel viewModel)
        {
            var existingCity = await _unitOfWork.InvestPortfolioes.GetByIdAsync(viewModel.ClientID);//получить id gjhnatkz
            if (existingCity is null)
            {
                var exception = new Exception($"InvestPortfolioes with id = {viewModel.ClientID} was not found");

                throw exception;
            }

            await _unitOfWork.InvestPortfolioes.DeleteAsync(existingCity);
        }
    }
}
