using InvestManager.ApplicatoinCore.Enums;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManager.ApplicatoinCore.QueryOptions;
using InvestManagerVer2.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace InvestManagerVer2.Web.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<LoginViewModel> Login(LoginViewModel model)
        {
            try
            {
                var options = new QueryEntityOptions<Client>().SetFilterOption(y => y.Email == model.Login);
                var users = await _unitOfWork.Clients.GetAllAsync(options);

                if (users is null)
                {
                    return null;
                }

                var user = users.First();

                if (user.Password == model.Password)
                {
                    return model;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RegisterViewModel> Register(RegisterViewModel model)
        {
            try
            {
                var newUser = new Client()
                {
                    Role = Role.Client,
                    Name = model.Name,
                    Email = model.Email,
                    Surname = model.Surname,
                    DateOfBirth = model.DateOfBirth,
                    NumberPhone = model.NumberPhone,
                    Password = model.Password
                };
            
                await _unitOfWork.Clients.CreateAsync(newUser);
            
                return model;
            }
            catch (Exception ex)
            {
                return model;
            }
        }
    }
}
