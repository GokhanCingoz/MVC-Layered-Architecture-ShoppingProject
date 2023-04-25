using BusinessLayer.Managements.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class ProfileController : Controller
    {


        public readonly IUserManagement _userManagement;

        public ProfileController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }
        public IActionResult Index()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var user = _userManagement.GetUserById(userId);
            var model = new UserModel()
            {
             
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                Username = user.Username
            };
            model.Id = userId;

            return View(model);
        }

    }
}
