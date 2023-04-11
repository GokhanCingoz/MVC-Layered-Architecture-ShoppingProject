using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        //Admin section
        Task<Product?> GetAsync(int id);
        Task<Product?> AddAsync(Product product);
        Product? Update(Product product);
        Product? Delete(Product product);
    }
}
