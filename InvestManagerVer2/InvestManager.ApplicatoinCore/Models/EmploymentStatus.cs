using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class EmploymentStatus
    {
        [Key]
        public Guid SatusID { get; set; }
        public string StatusName { get; set; }
    }
}
