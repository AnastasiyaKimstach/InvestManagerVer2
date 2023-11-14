using InvestManager.ApplicatoinCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; }
        public TransactionType TransactionType { get; set; }
        public float Price { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public Guid AssetInPortfolioID { get; set; }
        public AssetInPortfolio AssetInPortfolio { get; set; }
        public Guid PortfolionID { get; set; }
        public InvestPortfolio InvestPortfolio { get; set; }
    }
}
