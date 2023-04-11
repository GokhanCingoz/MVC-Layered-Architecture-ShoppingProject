using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ContextDb _contextDb;
        public ProductRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public List<Product> GetAllProducts()
        {
            //return _contextDb.Products.Include(x => x.Category).ToList();
            return _contextDb.Products.Include(x => x.Category).Where(x => x.IsDeleted == false).ToList();
        }
        
        //Admin section
        public async Task<Product?> AddAsync(Product product)
        {
            await _contextDb.AddAsync(product);
            await _contextDb.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await _contextDb.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Product? Update(Product product)
        {
            var existingProduct = _contextDb.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Id = product.Id;
                existingProduct.Title = product.Title;
                existingProduct.Description = product.Description;
                existingProduct.Brand = product.Brand;
                existingProduct.Price = product.Price;
                existingProduct.Rating = product.Rating;
                existingProduct.ImgLink = product.ImgLink;
                existingProduct.CategoryId= product.CategoryId;

                _contextDb.SaveChanges();
                return existingProduct;
            }

            return null;
        }
        public Product? Delete(Product product)
        {
            var existingProduct = _contextDb.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Id = product.Id;
                existingProduct.IsDeleted = true;

                _contextDb.SaveChanges();
                return existingProduct;
            }
            return null;
        }
    }
}
