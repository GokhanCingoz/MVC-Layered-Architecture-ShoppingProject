using Microsoft.AspNetCore.Mvc;

namespace Shopping.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
