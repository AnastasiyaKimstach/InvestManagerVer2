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
    public class Client : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfRegistration { get; set; } = DateTime.Now;

        [Phone]
        public string NumberPhone { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; } = 0;




        public void UpdateDetails(ClientDetails details)
        {
            Name = details.Name;
            Surname = details.Surname;
            Password = details.Password;
            NumberPhone = details.NumberPhone;
            Email = details.Email;
        }
        public readonly record struct ClientDetails
        {
            public string Name { get; }
            public string Surname { get; }
            public string Password { get; }
            public string NumberPhone { get; }
            public string Email { get; }

            public ClientDetails(string name, string surname, string password, string numberPhone,
                string email)
            {
                Name = name;
                Surname = surname;
                Password = password;
                NumberPhone = numberPhone;
                Email = email;
            }
        }
    }
}
