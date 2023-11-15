using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class Statistics : BaseModel
    {
        public InvestPortfolio? Portfolio { get; set; }
        public Guid PortfolioID { get; set; }
        public DateTime UpdateDate { get; set; }
        public float PortfolioProfitability { get; set; }
        public float PortfolioCost { get; set;}
    }
}
