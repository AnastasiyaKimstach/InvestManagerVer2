using Microsoft.AspNetCore.Mvc;

namespace InvestManagerVer2.Web.Controllers
{
    public class AssetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
