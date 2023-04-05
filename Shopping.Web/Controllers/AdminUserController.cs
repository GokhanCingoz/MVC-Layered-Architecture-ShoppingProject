using EntityLayer.Domain;
using Shopping.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Repositories.Interfaces;


namespace Shopping.Web.Controllers
{
    public class AdminUserController : Controller
        
    {
        //DI
        private readonly IUserRepository userRepository;
        public AdminUserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
       
        //User Add - Get Method
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //User Add - Post Method
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(UserModel userModel)
        {
            var user = new User
            {
                Name = userModel.Name,
                Surname = userModel.Surname,
                Password = userModel.Password,
                Username = userModel.Username,
                IsAdmin = userModel.IsAdmin

            };
            await userRepository.AddAsync(user);
            return View(user);
            //return RedirectToAction("List");
        }
        //User List - Get method
        [HttpGet]
        public IActionResult List()
        {
            var user =userRepository.GetAllUsers();
            return View(user);
        }
        //User Edit - Get Action
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await userRepository.GetAsync(id);

            if (user != null)
            {
                var editUserReq = new EditUserRequest
                {
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
        public async Task<IActionResult> Edit(EditUserRequest editUserRequest)
        {
            var user = new User
            {
                Name = editUserRequest.Name,
                Surname = editUserRequest.Surname,
                Password = editUserRequest.Password,
                Username = editUserRequest.Username,
                IsAdmin = editUserRequest.IsAdmin
            };
            

            var updatedUser = await userRepository.UpdateAsync(user);
            if (updatedUser != null)
            {
               
                return RedirectToAction("List");
            }
           
            return RedirectToAction("Edit", new { id = editUserRequest.Id });

        }

    }
}
