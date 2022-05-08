using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erp_ecommerce.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ERPContext context;

        public ProductRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product productDto)
        {
            Product product = new Product();
            context.Add(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return context.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Product.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            context.Remove(product);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Product.Any(x => x.ProductId == id);
        }
    }
}
