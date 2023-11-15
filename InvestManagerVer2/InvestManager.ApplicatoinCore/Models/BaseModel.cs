
using System.ComponentModel.DataAnnotations;

namespace InvestManager.ApplicatoinCore.Models
{
    public abstract class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
