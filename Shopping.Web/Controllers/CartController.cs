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

        public CartController(IProductManagement productManagement, ICartManagement cartManagement)
        {
            _productManagement = productManagement;
            _cartManagement = cartManagement;
        }
        public IActionResult Index()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var cartQuantity = GetCartQuantity();

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

            ViewData["CartQuantity"] = cartQuantity;

            return View(model);
        }

        public int GetCartQuantity()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cartQuantity = _cartManagement.GetCartQuantity(userId);

            return cartQuantity;
        }

        public IActionResult DeleteCart(int id)
        {
            _cartManagement.Delete(id);

            return Json(true);
        }

        public IActionResult IncreaseCartQuantity(int productId) {

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            var cart = new Cart
            {
                ProductId= productId,
                 UserId = userId,
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
    }
}
