using Microsoft.AspNetCore.Mvc;

namespace Shopping.Web.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
