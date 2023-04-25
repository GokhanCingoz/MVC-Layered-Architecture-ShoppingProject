using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class ProfileController : Controller
    {


        public readonly IUserManagement _userManagement;
        private readonly IUserRepository userRepository;
        public readonly ILoginManagement _loginManagement;


        public ProfileController(IUserRepository userRepository, IUserManagement userManagement, ILoginManagement loginManagement)
        {
            _userManagement = userManagement;
            this.userRepository = userRepository;
            _loginManagement = loginManagement;
        }
        public IActionResult Index()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var user = _userManagement.GetUserById(userId);
            var model = new UserModel()
            {
                Id = userId,
                Name = user.Name,
                Surname = user.Surname,
                Password = user.Password,
                Username = user.Username
            };
            model.Id = userId;

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(int userId)
        {
            var user = await _loginManagement.GetAsync(userId);

            if (user != null)
            {
                var editUserReq = new EditUserRequest
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    Password = user.Password,
                    Username = user.Username,
                    IsAdmin = user.IsAdmin
                };
                return View(editUserReq);
            }

            return View(null);

        }

        //User Edit - Get Action
        [HttpPost]
        public IActionResult EditUser(EditUserRequest editUserRequest)
        {
            var user = new User
            {
                Id = editUserRequest.Id,
                Name = editUserRequest.Name,
                Surname = editUserRequest.Surname,
                Password = editUserRequest.Password,
                Username = editUserRequest.Username,
                IsAdmin = editUserRequest.IsAdmin
            };

            var updatedUser = _loginManagement.UpdateAsync(user);

            return Json(updatedUser != null);
        }
    }
}
