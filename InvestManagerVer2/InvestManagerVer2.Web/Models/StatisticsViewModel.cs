using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManagerVer2.Web.Models
{
    public class StatisticsViewModel 
    {
        public InvestPortfolioViewModel? Portfolio { get; set; }
        public Guid PortfolioID { get; set; }
        public DateTime UpdateDate { get; set; }
        public float PortfolioProfitability { get; set; }
        public float PortfolioCost { get; set;}
    }
}
