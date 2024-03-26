using Microsoft.AspNetCore.Mvc;

namespace MarketManagement.Web.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
