using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;

namespace InvestManagerVer2.Web.Interfaces
{
    public interface ITransactionService
    {
        Task CreateTransactionAsync(TransactionViewModel viewModel);
    }
}
