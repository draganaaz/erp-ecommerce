using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IProductRepository
    {
#nullable enable
        public PagedResponse<List<Product>> GetAllProducts(string? query, int? categoryID, int? brandID,
            string? productType, int? colorID, int? sizeID, int? minPrice, int? maxPrice,
            string? sortOrder, int pageNumber, int pageSize);

        public Product GetProductById(int id);

        public void AddProduct(ProductDto productDto);

        public void UpdateProduct(Product product, ProductDto productDto);

        public void DeleteProduct(Product product);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
