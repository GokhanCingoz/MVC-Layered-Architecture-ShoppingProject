using EntityLayer.Domain;
using Shopping.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Repositories.Interfaces;
using BusinessLayer.Managements.Interfaces;

namespace Shopping.Web.Controllers
{
    public class AdminUserController : Controller

    {
        //DI
        public readonly ILoginManagement _loginManagement;
        private readonly IUserRepository userRepository;
        public AdminUserController(IUserRepository userRepository, ILoginManagement loginManagement)
        {
            this.userRepository = userRepository;
            _loginManagement = loginManagement;
        }

        //User Add - Get Method
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["IsAdmin"] = IsAdmin();
            return View();
        }

        //User Add - Post Method
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(UserModel userModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var user = new User
            {
                Name = userModel.Name,
                Surname = userModel.Surname,
                Password = userModel.Password,
                Username = userModel.Username,
                IsAdmin = userModel.IsAdmin

            };
            await _loginManagement.AddAsync(user);
            //return View(user);
            return RedirectToAction("List");
        }
        //User List - Get method
        [HttpGet]
        public IActionResult List()
        {
            var user = userRepository.GetAllUsers();
            ViewData["IsAdmin"] = IsAdmin();
            return View(user);
        }
        //User Edit - Get Action
        [HttpGet]
        public async Task<IActionResult> Edit(int userId)
        {
            ViewData["IsAdmin"] = IsAdmin();
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
            ViewData["IsAdmin"] = IsAdmin();
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
        //User Delete - Post Action
        [HttpPost]
        public IActionResult Delete(DeleteUserRequest deleteUserRequest)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var user = new User
            {
                Id= deleteUserRequest.Id,
                Name = deleteUserRequest.Name,
                Surname = deleteUserRequest.Surname,
                Password = deleteUserRequest.Password,
                Username = deleteUserRequest.Username,
                IsAdmin = deleteUserRequest.IsAdmin,
                IsDeleted = deleteUserRequest.IsDeleted
            };
            var deletedUser = userRepository.Delete(user);
            return Json(deletedUser != null);
        }

        public bool IsAdmin()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var IsAdmin = _loginManagement.UserAdminControl(userId);
            return IsAdmin;
        }
    }
}
