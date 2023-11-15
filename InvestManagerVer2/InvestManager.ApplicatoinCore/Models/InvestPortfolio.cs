using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class InvestPortfolio
    {
        [Key]
        public Guid PortfolioID { get; set; }

        public Client? Client { get; set; }
        public Guid ClientID { get; set; }

        public string PortfolioName { get; set;}
        public int PortfolioGoal { get; set; }
        public int InvestmentHorisont { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
