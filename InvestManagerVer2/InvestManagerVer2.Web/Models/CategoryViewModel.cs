
using InvestManager.ApplicatoinCore.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvestManagerVer2.Web.Models
{
    public class CategoryViewModel : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }
    }
}
