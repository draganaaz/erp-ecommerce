using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();

        public Product GetProductById(int id);

        public void AddProduct(Product productDto);

        public void UpdateProduct(Product product);

        public void DeleteProduct(Product product);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
