using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvestManagerVer2.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService cityViewModelService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryService = cityViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> IndexAdmin()
        {
            var categories = await _categoryService.GetCategoryAsync();
            List<CategoryViewModel> listCategory = new List<CategoryViewModel>();

            if (categories == null)
            {
                foreach(var category in categories)
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

        [HttpGet]
        public async Task<IActionResult> Create(CategoryViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(CategoryViewModel viewModel)
        {
            await _categoryService.DeleteCategoryAsync(viewModel);
            return RedirectToAction(nameof(Delete));
        }


    }
}
