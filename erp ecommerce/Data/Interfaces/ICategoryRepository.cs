using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories();

        public Category GetCategoryById(int id);

        public void AddCategory(Category categoryDto);

        public void UpdateCategory(Category category);

        public void DeleteCategory(Category category);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
