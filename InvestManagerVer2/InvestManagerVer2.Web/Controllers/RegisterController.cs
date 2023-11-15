using InvestManager.ApplicatoinCore.Models;
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
        public IActionResult Step1(Client model)
        {
            return RedirectToAction("Step2");
        }

        [HttpGet]
        public IActionResult Step2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Step2(Client model)
        {
            return RedirectToAction("Step3");
        }

        [HttpGet]
        public IActionResult Step3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Step3(Client model)
        {
            // Обработка данных из третьей формы
            // Завершение регистрации пользователя
            return RedirectToAction("RegistrationComplete");
        }

        //public IActionResult RegistrationComplete()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}
