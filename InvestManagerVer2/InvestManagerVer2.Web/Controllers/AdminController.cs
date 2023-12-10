using AutoMapper;
using InvestManager.ApplicatoinCore.Interfaces;
using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Interfaces;
using InvestManagerVer2.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestManagerVer2.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;

        public AdminController(ICategoryService cityViewModelService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _categoryService = cityViewModelService;
        }

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
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.GetCategoryViewModelByIdAsync(id);
            if (result == null)
            {
                return RedirectToAction("IndexAdmin");
            }

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(CategoryViewModel viewModel)
        {
            await _categoryService.DeleteCategoryAsync(viewModel);
            return RedirectToAction(nameof(IndexAdmin));
        }



        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var result = await _categoryService.GetCategoryViewModelByIdAsync(id);
        //    if (result == null)
        //    {
        //        return RedirectToAction("IndexA");//возвращение к странице аккауна
        //    }

        //    return View(result);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(CategoryViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _categoryService.Update(viewModel);//add updetw
        //        return RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
