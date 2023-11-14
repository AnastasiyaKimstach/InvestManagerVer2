using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Buy")]
        Buy = 0,
        [Display(Name = "Sale")]
        Sale = 1,
    }
}
