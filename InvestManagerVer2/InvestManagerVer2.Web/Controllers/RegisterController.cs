using InvestManager.ApplicatoinCore.Models;
using InvestManagerVer2.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace InvestManagerVer2.Web.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Step1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Step1(RegisterViewModel model)
        {
           return RedirectToAction("Step2");
        }

        [HttpGet]
        public IActionResult Step2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Step2(RegisterViewModel model)
        {
            return RedirectToAction("Step2");
        }

        

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult IndexAdmin() //RegisterViewModel model
        {
            return RedirectToAction("IndexAdmin","Admin");
        }


    }
}
