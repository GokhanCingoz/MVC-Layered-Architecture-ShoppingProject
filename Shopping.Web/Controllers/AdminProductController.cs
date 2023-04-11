﻿using BusinessLayer.Managements;
using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Migrations;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.AspNetCore.Mvc;
using Shopping.Web.Models;

namespace Shopping.Web.Controllers
{
    public class AdminProductController : Controller
    {
        public readonly ILoginManagement _loginManagement;
        public readonly IProductManagement _productManagement;
        public AdminProductController(IProductManagement productManagement, ILoginManagement loginManagement)
        {
            _productManagement = productManagement;
            _loginManagement = loginManagement;
        }
        //Product Get Method
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["IsAdmin"] = IsAdmin();
            return View();
        }
        //Product Add - Post Method
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(ProductModel productModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var product = new Product
            {
                Id = productModel.Id,
                Title = productModel.Title,
                Description = productModel.Description,
                Brand = productModel.Brand,
                Price = productModel.Price,
                Rating = productModel.Rating,
                ImgLink = productModel.ImgLink,
                CategoryId = productModel.CategoryId,

            };
            await _productManagement.AddAsync(product);
            //return View(user);
            return RedirectToAction("List");
        }
        //Product List - Get method
        [HttpGet]
        public IActionResult List()
        {
            var product = _productManagement.GetAllProduct();
            ViewData["IsAdmin"] = IsAdmin();
            return View(product);
        }
        //Product Edit - Get Action
        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var product = await _productManagement.GetAsync(productId);

            if (product != null)
            {
                var productModel = new ProductModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Description = product.Description,
                    Brand = product.Brand,
                    Price = product.Price,
                    Rating = product.Rating,
                    ImgLink = product.ImgLink,
                    CategoryId = product.CategoryId,
                };
                return View(productModel);
            }
            return View(null);

        }
        //Product Edit - Post Action
        [HttpPost]
        public IActionResult EditProduct(ProductModel productModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var product = new Product
            {
                Id = productModel.Id,
                Title = productModel.Title,
                Description = productModel.Description,
                Brand = productModel.Brand,
                Price = productModel.Price,
                Rating = productModel.Rating,
                ImgLink = productModel.ImgLink,
                CategoryId = productModel.CategoryId,
            };

            var updatedUser = _productManagement.Update(product);

            return Json(updatedUser != null);
        }
        //Product Delete - Post Action
        [HttpPost]
        public IActionResult Delete(ProductModel productModel)
        {
            ViewData["IsAdmin"] = IsAdmin();
            var product = new Product
            {
                Id= productModel.Id,
                IsDeleted = productModel.IsDeleted
            };
            var deletedProduct= _productManagement.Delete(product);
            return Json(deletedProduct);
        }
        public bool IsAdmin()
        {
            var userId = string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? 0 : int.Parse(HttpContext.Session.GetString("UserId"));
            var IsAdmin = _loginManagement.UserAdminControl(userId);
            return IsAdmin;
        }

    }
}