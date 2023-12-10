
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;

namespace InvestManager.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Asset> Assets { get; }

        public IRepository<AssetInPortfolio> AssetInPortfolioes { get; }

        public IRepository<AsssetPriceHistory> AsssetPriceHistoryes { get; }

        public IRepository<Category> Categoryes { get; }

        public IRepository<Client> Clients { get; }

        public IRepository<InvestPortfolio> InvestPortfolioes { get; }

        public IRepository<Statistics> Statistics { get; }

        public IRepository<Transaction> Transactions { get; }

        public UnitOfWork(IRepository<Asset> assets, IRepository<AssetInPortfolio> assetInPortfolioes, 
            IRepository<AsssetPriceHistory> asssetPriceHistoryes, IRepository<Category> categoryes, 
            IRepository<Client> clientes, 
            IRepository<InvestPortfolio> investPortfolioes, IRepository<Statistics> statistics,
            IRepository<Transaction> transactions)
        {
            Assets = assets;
            AssetInPortfolioes = assetInPortfolioes;
            AsssetPriceHistoryes = asssetPriceHistoryes;
            Categoryes = categoryes;
            Clients = clientes;
            InvestPortfolioes = investPortfolioes;
            Statistics = statistics;
            Transactions = transactions;
        }
    }
}
