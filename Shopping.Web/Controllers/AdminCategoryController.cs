using EntityLayer.Domain;
using Shopping.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Repositories.Interfaces;
using BusinessLayer.Managements.Interfaces;
using BusinessLayer.Managements;

namespace Shopping.Web.Controllers
{
    public class AdminCategoryController : Controller
    {
        public readonly ILoginManagement _loginManagement;
        private readonly IUserRepository userRepository;
        private readonly ICategoryManagement _categoryManagement;
        public AdminCategoryController(IUserRepository userRepository, ILoginManagement loginManagement, ICategoryManagement categoryManagement)
        {
            this.userRepository = userRepository;
            _categoryManagement = categoryManagement;
            _loginManagement = loginManagement;
        }
        //Category Add - Get Method
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["IsAdmin"] = IsAdmin();
            return View();
        }
        //Category Add - Post Method
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(CategoryModel categoryModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var category = new Category
            {
                //Id= categoryModel.Id,
                Name = categoryModel.Name,
                Icon = categoryModel.Icon,
            };
            await _categoryManagement.AddAsync(category);
            return RedirectToAction("List");
        }
        //Category List - Get method
        [HttpGet]
        public IActionResult List()
        {
            var category = _categoryManagement.GetAllCategories();
            ViewData["IsAdmin"] = IsAdmin();
            return View(category);
        }
        //Category Edit - Get Action
        [HttpGet]
        public async Task<IActionResult> Edit(int categoryId)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var category = await _categoryManagement.GetAsync(categoryId);

            if (category != null)
            {
                var categoryModel = new CategoryModel
                {
                    Id= category.Id,
                    Name = category.Name,
                    Icon = category.Icon,
                };
                return View(categoryModel);
            }

            return View(null);

        }

        //User Edit - Get Action
        [HttpPost]
        public IActionResult EditCategory(CategoryModel categoryModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var category = new Category
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Icon = categoryModel.Icon,
            };

            var updatedCategory = _categoryManagement.Update(category);

            return Json(updatedCategory != null);
        }

        //Category Delete - Post Action
        [HttpPost]
        public IActionResult Delete(CategoryModel categoryModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var category = new Category
            {

                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Icon = categoryModel.Icon,
                IsDeleted = categoryModel.IsDeleted
            };
            var deletedCategory = _categoryManagement.Delete(category);
            return Json(deletedCategory != null);
        }
        public bool IsAdmin()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var IsAdmin = _loginManagement.UserAdminControl(userId);
            return IsAdmin;
        }
    }
}
