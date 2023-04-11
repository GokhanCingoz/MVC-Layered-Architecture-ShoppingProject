using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface IProductManagement
    {
        List<Product> GetAllProduct();
        List<Product> GetProductsByCategoryId(int categoryId);
        Task<Product?> GetAsync(int id);
        Task<Product?> AddAsync(Product product);
        Product? Update(Product product);
        Product? Delete(Product product);

    }
}
