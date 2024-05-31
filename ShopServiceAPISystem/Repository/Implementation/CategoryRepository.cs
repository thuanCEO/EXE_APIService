using BusinessObjects.Models;
using DataAccessObjects;
using Repository.Interfaces;
using System.Collections.Generic;

namespace Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _dao;

        public CategoryRepository(CategoryDAO dao)
        {
            _dao = dao;
        }

        public void CreateCategory(Category category)
        {
            _dao.CreateCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _dao.UpdateCategory(category);
        }

        public void DeleteCategory(int id)
        {
            _dao.DeleteCategory(id);
        }

        public List<Category> GetAllCategories()
        {
            return _dao.GetAllCategories();
        }

        public Category GetCategoryById(int id)
        {
            return _dao.GetCategoryById(id);
        }
        public void UpdateCategoryStatus(int id, int status)
        {
            _dao.UpdateCategoryStatus(id, status);
        }

    }
}
