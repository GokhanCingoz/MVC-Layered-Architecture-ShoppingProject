using BusinessLayer.Managements.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class FavoriteController : Controller
    {
        public readonly IFavoriteManagement _favoriteManagement;
        public readonly ICartManagement _cartManagement;

        public FavoriteController(IFavoriteManagement favoriteManagement, ICartManagement cartManagement)
        {
            _favoriteManagement = favoriteManagement;
            _cartManagement = cartManagement;
        }
        public IActionResult Index()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favorites = _favoriteManagement.GetAllFavoritesByUserId(userId);
            var model = new List<FavoriteModel>();

            foreach (var item in favorites)
            {
                var favoriteModel = new FavoriteModel
                {
                    Id = item.Id,
                    ProductId = item.ProductId,
                    UserId = item.UserId,
                    Product = new ProductModel
                    {
                        ImgLink = item.Product.ImgLink,
                        Title = item.Product.Title,
                        Price = item.Product.Price,
                        Category = new CategoryModel
                        {
                            Id = item.Product.Category.Id,
                            Name = item.Product.Category.Name,
                        },
                    }
                };

                model.Add(favoriteModel);
            }

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

        public int GetAllFavoritesQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favoriteQuantity = _favoriteManagement.GetAllFavoritesQuantity(userId);

            return favoriteQuantity;
        }

        public IActionResult DeleteFavorite(int productId)
        {
            _favoriteManagement.DeleteFavorite(productId);

            return Json(true);
        }

        public bool AddToCart(int productId)
        {
            var result = true;

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            if (userId == 0)
            {
                result = false;
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
