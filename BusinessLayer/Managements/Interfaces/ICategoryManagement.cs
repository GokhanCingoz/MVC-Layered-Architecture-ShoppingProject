using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements.Interfaces
{
    public interface ICategoryManagement 
    {
        List<Category> GetAllCategories();
        Task<Category?> AddAsync(Category category);
        Task<Category?> GetAsync(int id);
        Category? Update(Category category);
        Category? Delete(Category category);

    }
}
