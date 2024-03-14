using Microsoft.AspNetCore.Mvc;

namespace BWI.JAN20.Ecommerce.Web.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
