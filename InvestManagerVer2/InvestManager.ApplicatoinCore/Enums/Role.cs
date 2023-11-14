using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Enums
{
    public enum Role
    {
        [Display(Name = "Client")]
        Client = 0,
        [Display(Name = "Admin")]
        Admin = 1,
    }
}
