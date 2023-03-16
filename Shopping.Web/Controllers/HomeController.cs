using BusinessLayer.Managements.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IProductManagement _productManagement;

        public HomeController(IProductManagement productManagement)
        {
            _productManagement = productManagement;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index()
        {
            var products = _productManagement.GetAllProduct();
            var model = new List<ProductModel>();

            foreach (var item in products)
            {
                var product = new ProductModel
                {
                    Brand = item.Brand,
                    Category = item.Category,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    Id = item.Id,
                    ImgLink = item.ImgLink,
                    Price = item.Price,
                    Rating = item.Rating,
                    Stock = item.Stock,
                    Title = item.Title,
                };
                model.Add(product);
            }

            ViewBag.Title = "Home Page";

            return View(model);
        }


        public IActionResult ProductsByCategory(int categoryId)
        {   
            var productsFromDatabase=_productManagement.GetProductsByCategoryId(categoryId);
            var model = new List<ProductModel>();

            foreach (var item in productsFromDatabase)
            {
                var productByCategoryId= new ProductModel
                {
                    Brand = item.Brand,
                    Category = item.Category,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
                    Id = item.Id,
                    ImgLink = item.ImgLink,
                    Price = item.Price,
                    Rating = item.Rating,
                    Stock = item.Stock,
                    Title = item.Title,
                };

                model.Add(productByCategoryId); 
            }

            ViewBag.Title = model.FirstOrDefault() != null ? model.FirstOrDefault().Category.Name : "";

            return View("Index", model);
        }

        

    }
}