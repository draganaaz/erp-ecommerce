using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erp_ecommerce.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ERPContext context;

        public CategoryRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddCategory(Category categoryDto)
        {
            Category category = new Category();
            context.Add(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return context.Category.ToList();   
        }

        public Category GetCategoryById(int id)
        {
            return context.Category.Where(x => x.CategoryId == id).FirstOrDefault();
        }

        public void UpdateCategory(Category category, CategoryDto categoryDto)
        {
            category.Category1 = categoryDto.Category;
        }

        public void DeleteCategory(Category category)
        {
            context.Remove(category);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Category.Any(x => x.CategoryId == id);
        }
    }
}
