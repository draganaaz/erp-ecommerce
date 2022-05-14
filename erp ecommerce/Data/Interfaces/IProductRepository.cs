using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IProductRepository
    {
#nullable enable
        public IEnumerable<Product> GetAllProducts(string query = "", int categoryID = 0, int brandID = 0,
            string productType = "", int colorID = 0, int sizeID = 0, int minPrice = 0, int maxPrice = 0,
            string sortOrder = "");

        public Product GetProductById(int id);

        public void AddProduct(Product productDto);

        public void UpdateProduct(Product product, ProductDto productDto);

        public void DeleteProduct(Product product);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
