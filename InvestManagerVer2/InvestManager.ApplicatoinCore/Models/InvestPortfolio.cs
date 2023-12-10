using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class InvestPortfolio : BaseModel
    {
        public Client Client { get; set; }
        public Guid ClientID { get; set; }

        public string PortfolioName { get; set;}
        public int PortfolioGoal { get; set; }
        public int InvestmentHorisont { get; set; }
        public DateTime CreateDate { get; set; }

        public void UpdateDetails(InvestPortfolioDetails details)
        {
            Client = details.Client;
            ClientID = details.ClientID;
            PortfolioName = details.PortfolioName;
            PortfolioGoal = details.PortfolioGoal;
            InvestmentHorisont = details.InvestmentHorisont;
            CreateDate = details.CreateDate;
        }

        public readonly record struct InvestPortfolioDetails
        {
            public Client Client { get;}
            public Guid ClientID { get;}

            public string PortfolioName { get;}
            public int PortfolioGoal { get;}
            public int InvestmentHorisont { get; }
            public DateTime CreateDate { get; }

            public InvestPortfolioDetails(Client client, Guid clientID, string portfolioName, int portfolioGoal,
                int investmentHorisont, DateTime createDate)
            {
                Client = client;
                ClientID = clientID;
                PortfolioName = portfolioName;
                PortfolioGoal = portfolioGoal;
                InvestmentHorisont = investmentHorisont;
                CreateDate = createDate;
            }
        }
    }
}
