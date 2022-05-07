using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
