using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        //Admin section
        Task<Category?> AddAsync(Category category);
        Task<Category?> GetAsync(int id);
        Category? Update(Category category);
        Category? Delete(Category category);
    }
}
