using BusinessLayer.Managements.Interfaces;
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
        public List<Product> GetAllProduct()
        {
            return _productRepository.GetAllProducts();
        }

        public List<Product> GetProductsByCategoryId(int id)
        {
            return _productRepository.GetAllProducts().Where(x => x.CategoryId == id).ToList();
        }
    }
}
