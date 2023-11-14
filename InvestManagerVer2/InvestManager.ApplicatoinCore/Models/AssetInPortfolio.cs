using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class AssetInPortfolio
    {
        [Key]
        public Guid AssetInPortfolioID { get; set; }
        public Guid AssetID { get; set; }
        public Asset Asset { get; set; }
        public int Quantity { get; set; }
        public Guid CategotyID { get; set; }
        public Category? Category { get; set; }
        public Guid PortfolioID { get; set; }
        public InvestPortfolio? Portfolio{ get; set; }
    }
}
