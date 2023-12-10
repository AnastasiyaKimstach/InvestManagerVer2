using InvestManagerVer2.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManagerVer2.Wer.Models
{
    public class AsssetPriceHistoryViewModel
    {
        public float Price {  get; set; }
        public DateTime Timestamp { get; set;}

        public AssetViewModel? Asset { get; set; }
        public Guid AssetID { get; set; }
    }
}
