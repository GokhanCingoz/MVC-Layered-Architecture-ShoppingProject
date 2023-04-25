using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class DeliveryController : Controller
    {
        public readonly IDeliveryManagement _deliveryManagement;
        public readonly IProductManagement _productManagement;
        public readonly ICartManagement _cartManagement;
        public readonly IFavoriteManagement _favoriteManagement;
        public readonly ILoginManagement _loginManagement;
        public readonly IUserManagement _userManagement;

        public DeliveryController(IDeliveryManagement deliveryManagement, IProductManagement productManagement, ICartManagement cartManagement, IFavoriteManagement favoriteManagement, ILoginManagement loginManagement, IUserManagement userManagement)
        {
            _productManagement = productManagement;
            _cartManagement = cartManagement;
            _favoriteManagement = favoriteManagement;
            _loginManagement = loginManagement;
            _userManagement = userManagement;
            _deliveryManagement= deliveryManagement;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "My Orders";

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));

            SetCommonViewData(userId);

            var deliveries = _deliveryManagement.GetDeliveryByUserId(userId);

            var model = new List<DeliveryModel>();

            foreach (var item in deliveries)
            {
                var deliveryModel = new DeliveryModel
                {
                    Id= item.Id,
                    Adress = item.Adress,
                    Date = item.Date,
                    Email = item.Email,
                    Name = item.Name,
                    SurName = item.SurName,
                    PhoneNum = item.PhoneNum,
                    TotalPrice = item.TotalPrice,
                    TotalQuantity = item.TotalQuantity,
                };

                foreach (var deliveryItem in item.DeliveryDetail)
                {
                    deliveryModel.DeliveryDetails.Add(new DeliveryDetailModel
                    {
                        TotalPrice = deliveryItem.TotalPrice,
                        Quantity = deliveryItem.Quantity,
                        ProductId = deliveryItem.ProductId,
                        Product = new ProductModel
                        {
                            Brand = deliveryItem.Product.Brand,
                            ImgLink = deliveryItem.Product.ImgLink,
                            Title = deliveryItem.Product.Title,
                            
                        }
                    });
                }
                model.Add(deliveryModel);
            }
            return View(model);
        }

        public ActionResult DeliveryDetail(int? id)
        {
            ViewData["Title"] = "My Orders";

            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var delivery = _deliveryManagement.GetDeliveryByUserId(userId).FirstOrDefault(x=>x.Id== id);
            var deliveryModel = new DeliveryModel
            {
                Adress = delivery.Adress,
                Date = delivery.Date,
                Email = delivery.Email,
                Name = delivery.Name,
                SurName = delivery.SurName,
                PhoneNum = delivery.PhoneNum,
                TotalPrice = delivery.TotalPrice,
                TotalQuantity = delivery.TotalQuantity,
            };

            foreach (var deliveryItem in delivery.DeliveryDetail)
            {
                deliveryModel.DeliveryDetails.Add(new DeliveryDetailModel
                {
                    TotalPrice = deliveryItem.TotalPrice,
                    Quantity = deliveryItem.Quantity,
                    ProductId = deliveryItem.ProductId,
                    Product = new ProductModel
                    {
                        Brand = deliveryItem.Product.Brand,
                        ImgLink = deliveryItem.Product.ImgLink,
                        Title = deliveryItem.Product.Title,

                    }
                });
            }
            return PartialView("DeliveryDetailPartialView",deliveryModel);
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
        private void SetCommonViewData(int userId)
        {

            var cartQuantity = GetAllCartsQuantity();
            ViewData["TotalCartsQuantity"] = cartQuantity;

            var totalPrice = _cartManagement.TotalPrice(userId);
            ViewData["TotalPrice"] = string.Format("{0:N2} €", totalPrice);

            var favoritesQuantity = GetAllFavoritesQuantity();
            ViewData["FavoriteQuantity"] = favoritesQuantity;
        }


    }
}
