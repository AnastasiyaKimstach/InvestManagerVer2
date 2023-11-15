
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

        public IRepository<ChangePrice> ChangePrices { get; }

        public IRepository<Client> Clients { get; }

        public IRepository<Country> Countryes { get; }

        public IRepository<EmploymentStatus> EmploymentStatus { get; }

        public IRepository<InvestPortfolio> InvestPortfolioes { get; }

        public IRepository<Statistics> Statistics { get; }

        public IRepository<Transaction> Transactions { get; }

        public UnitOfWork(IRepository<Asset> assets, IRepository<AssetInPortfolio> assetInPortfolioes, 
            IRepository<AsssetPriceHistory> asssetPriceHistoryes, IRepository<Category> categoryes, 
            IRepository<ChangePrice> changePrices, IRepository<Client> clientes, 
            IRepository<Country> countryes, IRepository<EmploymentStatus> employmentStatus,
            IRepository<InvestPortfolio> investPortfolioes, IRepository<Statistics> statistics,
            IRepository<Transaction> transactions)
        {
            Assets = assets;
            AssetInPortfolioes = assetInPortfolioes;
            AsssetPriceHistoryes = asssetPriceHistoryes;
            Categoryes = categoryes;
            ChangePrices = changePrices;
            Clients = clientes;
            Countryes = countryes;
            EmploymentStatus = employmentStatus;
            InvestPortfolioes = investPortfolioes;
            Statistics = statistics;
            Transactions = transactions;
        }
    }
}
