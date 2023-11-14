using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestManager.ApplicatoinCore.Models;
using Microsoft.EntityFrameworkCore; 

namespace InvestManager.Infrastructure.Data
{
    public class InvestManagerContext : DbContext
    {
        
        public InvestManagerContext(DbContextOptions<InvestManagerContext> options)
            :base(options)
        {

        }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetInPortfolio> AssetsInPortfolio { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ChangePrice> ChangesPrice { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmploymentStatus> EmploymentStatuses { get; set; }
        public DbSet<InvestPortfolio> InvestPortfolios { get; set; }
        public DbSet<Statistics> Statistices { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
