using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class AsssetPriceHistory : BaseModel
    {
        public float Price {  get; set; }
        public DateTime Timestamp { get; set;}

        public Asset? Asset { get; set; }
        public Guid AssetID { get; set; }
    }
}
