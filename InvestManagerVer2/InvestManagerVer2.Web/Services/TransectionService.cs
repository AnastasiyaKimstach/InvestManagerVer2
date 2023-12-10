using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Services
{
    public class TransectionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransectionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateTransactionAsync(TransactionViewModel viewModel)
        {
            var dto = _mapper.Map<Transaction>(viewModel);
            await _unitOfWork.Transactions.CreateAsync(dto);
        }
    }
}
