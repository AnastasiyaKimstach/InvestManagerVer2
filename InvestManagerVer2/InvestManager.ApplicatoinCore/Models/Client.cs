using InvestManager.ApplicatoinCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestManager.ApplicatoinCore.Models
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Pathronumic { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; }= DateTime.Now;
        public bool Gender { get; set; }
        public Guid CountryID { get; set; }
        public Country Country { get; set; }
        public Guid StatusID { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        [Phone]
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = 0;
    }
}
