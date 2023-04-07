using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDb _contextDb;

        public CategoryRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public List<Category> GetAllCategories()
        {
           return _contextDb.Categories.ToList();
        }
    }
}
