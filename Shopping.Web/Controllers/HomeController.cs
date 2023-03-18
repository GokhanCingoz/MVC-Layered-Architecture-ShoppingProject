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
        public readonly  IFavoriteManagement _favoriteManagement;

        public HomeController(IProductManagement productManagement, ICartManagement cartManagement, IFavoriteManagement favoriteManagement)
        {
            _productManagement = productManagement;
            _cartManagement = cartManagement;
            _favoriteManagement = favoriteManagement;
        }

        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index()
        {

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favoriteProductIds = _favoriteManagement.GetAllFavoritesByUserId(userId).Select(x => x.ProductId);

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
                    IsFavorite = favoriteProductIds.Any(x => x == item.Id)
                };
                model.Add(product);
            }

            ViewData["Title"] = "Home Page";

            var cartQuantity = GetAllCartsQuantity();

            ViewData["TotalCartsQuantity"] = cartQuantity;

            var favoritesQuantity = GetAllFavoritesQuantity();

            ViewData["FavoriteQuantity"] = favoritesQuantity;

            

            return View(model);
        }

        public int GetAllCartsQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cartQuantity = _cartManagement.GetAllCartsQuantity(userId);

            return cartQuantity;
        }


        public IActionResult ProductsByCategory(int categoryId)
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favoriteProductIds = _favoriteManagement.GetAllFavoritesByUserId(userId).Select(x => x.ProductId);

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
                    IsFavorite = favoriteProductIds.Any(x => x == item.Id)

                };

                model.Add(productByCategoryId); 
            }

            ViewData["Title"] = model.FirstOrDefault() != null ? model.FirstOrDefault().Category.Name : "";

            var cartQuantity = GetAllCartsQuantity();

            ViewData["TotalCartsQuantity"] = cartQuantity;

            var favoritesQuantity = GetAllFavoritesQuantity();

            ViewData["FavoriteQuantity"] = favoritesQuantity;

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

        public IActionResult AddToFavorite(int productId)
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            
            var favorite = new Favorite
            {
                ProductId = productId,
                UserId = userId,
            };

            _favoriteManagement.AddFavorite(favorite);

            return Json(true);
        }

        public IActionResult RemoveFromFavorite(int productId)
        {
            _favoriteManagement.DeleteFavorite(productId);

            return Json(true);
        }

        public int GetAllFavoritesQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favoriteQuantity = _favoriteManagement.GetAllFavoritesQuantity(userId);

            return favoriteQuantity;
        }

    }
}