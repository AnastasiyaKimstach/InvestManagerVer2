
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;

namespace InvestManager.ApplicatoinCore.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Asset> Assets { get; }
        IRepository<AssetInPortfolio> AssetInPortfolioes { get; }
        IRepository<AsssetPriceHistory> AsssetPriceHistoryes { get; }
        IRepository<Category> Categoryes { get; }
        IRepository<Client> Clients { get; }
        IRepository<InvestPortfolio> InvestPortfolioes { get; }
        IRepository<Statistics> Statistics { get; }
        IRepository<Transaction> Transactions { get; }
    }
}
