using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InvestManagerVer2.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;
        private readonly IClientService _clientService;

        public async Task<IActionResult> IndexAdmin()
        {
            var categories = await _categoryService.GetCategoryAsync();
            List<CategoryViewModel> listCategory = new List<CategoryViewModel>();

            if (categories != null)
            {
                foreach (var category in categories)
                {
                    var CategoryViewNodel = new CategoryViewModel()
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName
                    };
                    listCategory.Add(CategoryViewNodel);
                }
                return View(listCategory);
            }
            return View();
        }

        public AdminController(IClientService clientService,ICategoryService cityViewModelService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryService = cityViewModelService;
            _clientService = clientService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<CategoryViewModel>(viewModel);
                await _categoryService.CreateCategoryAsync(viewModel);
                return RedirectToAction(nameof(IndexAdmin));
            }
            else
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditAccount(Guid id)
        {
            var result = await _clientService.GetClientViewModelByIdAsync(id);
            if (result == null)
            {
                return RedirectToAction("Account");
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccount(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _clientService.UpdateClientAsync(viewModel);
                return RedirectToAction(nameof(Account));
            }
            else
            {
                return View();
            }
        }


        public async Task<IActionResult> Account()
        {
            var clients = await _clientService.GetClientAsync();
            List<RegisterViewModel> listClient = new List<RegisterViewModel>();

            if (clients != null)
            {
                foreach (var client in clients)
                {
                    if (client.Role == InvestManager.ApplicatoinCore.Enums.Role.Admin) 
                    {
                        var clientViewModel = new RegisterViewModel()
                        {
                            Name = client.Name,
                            Surname = client.Surname,
                            Password = client.Password,
                            DateOfBirth = client.DateOfBirth,
                            DateOfRegistration = client.DateOfRegistration,
                            NumberPhone = client.NumberPhone,
                            Email = client.Email
                        };
                        listClient.Add(clientViewModel);
                    }
                }
                return View(listClient);
            }
            return View();
        }
    }
}
