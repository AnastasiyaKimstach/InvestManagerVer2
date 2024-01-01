using AutoMapper;
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
        private readonly IMapper _mapper;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        public async Task<List<RegisterViewModel>> GetClientAsync()
        {
            var options = new QueryEntityOptions<Client>().AddSortOption(false, x => x.Name);
            var entities = await _unitOfWork.Clients.GetAllAsync(options);
            var categoryes = _mapper.Map<List<RegisterViewModel>>(entities);

            return categoryes;
        }

        public async Task<RegisterViewModel> GetClientViewModelByIdAsync(Guid id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client == null)
            {
                var exception = new Exception($"Client with id = {id} was not found");

                throw exception;
            }

            var dto = _mapper.Map<RegisterViewModel>(client);

            return dto;
        }

        public async Task UpdateClientAsync(RegisterViewModel viewModel)
        {
            var existingClient = await _unitOfWork.Clients.GetByIdAsync(viewModel.Id);
            if (existingClient is null)
            {
                var exception = new Exception($"Client {viewModel.Id} was not found");
                throw exception;
            }

            Client.ClientDetails details = new Client.ClientDetails(viewModel.Name, viewModel.Surname, viewModel.Password, viewModel.NumberPhone, viewModel.Email);
            existingClient.UpdateDetails(details);
            await _unitOfWork.Clients.UpdateAsync(existingClient);
        }
    }
}
