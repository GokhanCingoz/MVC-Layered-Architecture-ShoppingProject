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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDb _contextDb;
        public CategoryRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }
        public List<Category> GetAllCategories()
        {
            //return _contextDb.Categories.ToList();
            return _contextDb.Categories.Where(x => x.IsDeleted == false).ToList();
        }
        //Admin section
        public async Task<Category?> AddAsync(Category category)
        {
            await _contextDb.AddAsync(category);
            await _contextDb.SaveChangesAsync();
            return category;
        }
        public async Task<Category?> GetAsync(int id)
        {
            return await _contextDb.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
        public Category? Update(Category category)
        {
            var existingCategory = _contextDb.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Icon = category.Icon;

                _contextDb.SaveChanges();
                return existingCategory;
            }
            return null;
        }
        public Category? Delete(Category category)
        {
            var existingCategory = _contextDb.Categories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Icon = category.Icon;
                existingCategory.IsDeleted = true;
                
                _contextDb.SaveChanges();
                return existingCategory;
            }
            return null;
        }

    }
}
