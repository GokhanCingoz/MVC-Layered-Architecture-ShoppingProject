using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Context;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class LoginController : Controller
    {
        public readonly ILoginManagement _loginManagement;

        public LoginController(ILoginManagement loginManagement)
        {
            _loginManagement = loginManagement;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LoginControl")]
        public IActionResult LoginControl(UserModel userModel)
        {
            var result = _loginManagement.LoginControl(userModel.Username, userModel.Password);

            return Json(result);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignUp")]
        public IActionResult SignUp(UserModel userModel)
        {
           var userControl= _loginManagement.UserNameControl(userModel.Username);

            if (!userControl)
            {
                var user = new User
                {
                    Username = userModel.Username,
                    Password = userModel.Password,
                    Name = userModel.Name,
                    Surname = userModel.Surname,
                };

                _loginManagement.SignUpUser(user);

                return Json(new { Result = true, Message = ""});
            }
            else
            {
                return Json(new { Result = false, Message = "The user is already exist!!!" });
            }
        }

        
    }
}
