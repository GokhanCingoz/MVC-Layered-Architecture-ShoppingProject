using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements
{
    public class ProductManagement : IProductManagement
    {
        private readonly IProductRepository _productRepository;

        public ProductManagement(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetProductsByCategoryId(int id)
        {
            return _productRepository.GetAllProducts().Where(x => x.CategoryId == id).ToList();
        }
        //Admin
        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAllProducts();
        }
        public async Task<Product?> AddAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<Product?> GetAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }
        public Product? Update(Product product)
        {
            return _productRepository.Update(product);
        }
        public Product? Delete(Product product)
        {
            return _productRepository.Delete(product);
        }
    }
}
