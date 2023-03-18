using BusinessLayer.Managements.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class HomeController : Controller
    {
        public readonly IProductManagement _productManagement;
        public readonly  ICartManagement _cartManagement;

        public HomeController(IProductManagement productManagement, ICartManagement cartManagement)
        {
            _productManagement = productManagement;
            _cartManagement = cartManagement;
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
                    Category = new CategoryModel
                    {
                        Id = item.Category.Id,
                        Name = item.Category.Name,
                    },
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

            ViewData["Title"] = "Home Page";

            var cartQuantity = GetCartQuantity();

            ViewData["CartQuantity"] = cartQuantity;

            return View(model);
        }

        public int GetCartQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cartQuantity = _cartManagement.GetCartQuantity(userId);

            return cartQuantity;
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
                    Category = new CategoryModel
                    {
                        Id = item.Category.Id,
                        Name = item.Category.Name,
                    },
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

            ViewData["Title"] = model.FirstOrDefault() != null ? model.FirstOrDefault().Category.Name : "";

            return View("Index", model);
        }
            
        public bool AddToCart(int productId)
        {   
            var result = true;

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            if (userId == 0)
            {
                result= false;
                return result;
            }

            var cart = new Cart
            {
                ProductId = productId,
                UserId = userId,
                Quantity = 1,

            };

            _cartManagement.AddCart(cart);
                
            return result;
        }
        


    }
}