

namespace InvestManagerVer2.Web.Models
{
    public class AssetInPortfolioViewModel
    {
        public AssetViewModel? Asset { get; set; }
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public CategoryViewModel? Category { get; set; }
        public Guid CategotyID { get; set; }


        public InvestPortfolioViewModel? Portfolio { get; set; }
        public Guid PortfolioID { get; set; }

    }
}
