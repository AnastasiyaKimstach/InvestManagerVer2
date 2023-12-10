using InvestManager.ApplicatoinCore.Enums;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManagerVer2.Web.Models
{
    public class TransactionViewModel
    {
        public TransactionType TransactionType { get; set; }
        public float Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

        public AssetInPortfolioViewModel? AssetInPortfolio { get; set; }
        public Guid AssetInPortfolioID { get; set; }

        public InvestPortfolioViewModel? InvestPortfolio { get; set; }
        public Guid PortfolionID { get; set; }
    }
}
