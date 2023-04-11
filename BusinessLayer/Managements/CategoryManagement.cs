using BusinessLayer.Managements.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Managements
{
    public class CategoryManagement : ICategoryManagement
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public CategoryManagement(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
        //Admin section
        public async Task<Category> AddAsync(Category category)
        {
            return await _categoryRepository.AddAsync(category);
        }
        public async Task<Category?> GetAsync(int id)
        {
            return await _categoryRepository.GetAsync(id);
        }

        public Category? Update(Category category)
        {
            return _categoryRepository.Update(category);
        }
        public Category? Delete(Category category)
        {
            return _categoryRepository.Delete(category);
        }
        
    }
}