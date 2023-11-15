using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class ChangePrice : BaseModel
    {
        public float Price { get; set; }
        public string Month { get; set; }//добавить перечисление
        [Range(2000, 2030)]
        public int Year { get; set; }
    }
}
