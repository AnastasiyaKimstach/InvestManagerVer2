using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class Asset
    {
        [Key]
        public Guid AssetID { get; set; }
        public string AssetName { get; set; }
        public string Ticker { get; set; }
        public string Category { get; set; }
        public float CurrentPrice { get; set; }
    }
}
