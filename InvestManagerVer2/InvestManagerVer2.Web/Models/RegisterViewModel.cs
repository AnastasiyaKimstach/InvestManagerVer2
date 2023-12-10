using InvestManager.ApplicatoinCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManagerVer2.Web.Models { 
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }= DateTime.Now;

        [Phone]
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = 0;
    }
}
