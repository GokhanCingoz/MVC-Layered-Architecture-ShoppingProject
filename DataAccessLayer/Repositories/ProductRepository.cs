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
            return _contextDb.Products.Include(x => x.Category).ToList();
        }
    }
}
