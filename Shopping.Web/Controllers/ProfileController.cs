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
        public readonly ICartManagement _cartManagement;
        public readonly IFavoriteManagement _favoriteManagement;
        public readonly ICategoryManagement _categoryManagement;


        public ProfileController(IUserRepository userRepository, IUserManagement userManagement, ILoginManagement loginManagement, ICategoryManagement categoryManagement,IFavoriteManagement favoriteManagement,ICartManagement cartManagement)
        {
            _userManagement = userManagement;
            this.userRepository = userRepository;
            _loginManagement = loginManagement;
            _categoryManagement = categoryManagement;
            _favoriteManagement = favoriteManagement;
            _cartManagement = cartManagement;

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

            ViewData["Title"] = "Profile";

            var cartQuantity = _cartManagement.GetAllCartsQuantity(userId);

            ViewData["TotalCartsQuantity"] = cartQuantity;

            var favoritesQuantity = _favoriteManagement.GetAllFavoritesQuantity(userId);

            ViewData["FavoriteQuantity"] = favoritesQuantity;

            var IsAdmin = _loginManagement.UserAdminControl(userId);

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int userId)
        {
            var userIdFor = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            ViewData["Title"] = "Edit Profile";
            var user = await _loginManagement.GetAsync(userId);

            var cartQuantity = _cartManagement.GetAllCartsQuantity(userIdFor);

            ViewData["TotalCartsQuantity"] = cartQuantity;

            var favoritesQuantity = _favoriteManagement.GetAllFavoritesQuantity(userIdFor);

            ViewData["FavoriteQuantity"] = favoritesQuantity;
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
