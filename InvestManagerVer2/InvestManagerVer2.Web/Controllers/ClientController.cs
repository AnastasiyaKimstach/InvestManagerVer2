using Microsoft.AspNetCore.Mvc;

namespace InvestManagerVer2.Web.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
