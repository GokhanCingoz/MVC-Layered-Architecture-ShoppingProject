using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class CartController : Controller
    {
        public readonly IProductManagement _productManagement;
        public readonly ICartManagement _cartManagement;
        public readonly IFavoriteManagement _favoriteManagement;


        public CartController(IProductManagement productManagement, ICartManagement cartManagement, IFavoriteManagement favoriteManagement)
        {
            _productManagement = productManagement;
            _cartManagement = cartManagement;
            _favoriteManagement = favoriteManagement;
        }
        public IActionResult Index()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var cartQuantity = GetAllCartsQuantity();

            var carts = _cartManagement.GetAllCartByUserId(userId);

            var model = new List<CartModel>();

            foreach (var item in carts)
            {
                var cartModel = new CartModel
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
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

                model.Add(cartModel);
            }

            var totalPrice = _cartManagement.TotalPrice(userId);

            ViewData["TotalCartsQuantity"] = cartQuantity;
            ViewData["TotalPrice"] = string.Format("{0:N2} €", totalPrice);

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

        public IActionResult DeleteCart(int id)
        {
            _cartManagement.DeleteCart(id);

            return Json(true);
        }

        public IActionResult IncreaseCartQuantity(int productId) {

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = new Cart
            {
                ProductId = productId,
                UserId = userId,
                Quantity = 1
            };
            _cartManagement.AddCart(cart);

            return Json(true);
        
        }
        public IActionResult DecreaseCartQuantity(int productId)
        {

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = new Cart
            {
                ProductId = productId,
                UserId = userId,
            };
            _cartManagement.DecraseCartQuantity(cart);

            return Json(true);

        }

        public IActionResult GetTotalCartsPrice()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var totalPrice = _cartManagement.TotalPrice(userId);

            return Json(string.Format("{0:N2} €", totalPrice));

        }

        public int GetAllFavoritesQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var favoriteQuantity = _favoriteManagement.GetAllFavoritesQuantity(userId);

            return favoriteQuantity;
        }
    }
}
