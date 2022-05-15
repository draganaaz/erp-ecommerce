using erp_ecommerce.Entities;
using erp_ecommerce.Models;
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

#nullable enable
        public IEnumerable<Product> GetAllProducts(string query = "", int categoryID = 0, int brandID = 0,
            string productType = "", int colorID = 0, int sizeID = 0, int minPrice = 0, int maxPrice = 0, 
            string sortOrder = "")
        {
            // Search bar
            if (!String.IsNullOrEmpty(query))
                return context.Product.Where(x => x.Name.Contains(query) || x.Description.Contains(query));

            // Sorting
            if (!String.IsNullOrEmpty(sortOrder))
            {
                return sortOrder switch
                {
                    "name_desc" => context.Product.OrderByDescending(x => x.Name),
                    "price" => context.Product.OrderBy(x => x.Price),
                    "price_desc" => context.Product.OrderByDescending(x => x.Price),
                    _ => context.Product.OrderBy(x => x.Name),
                };
            }

            // Filters
            // TODO: add prices filtering and fix colors and sizes n:n
            if (categoryID != null) return context.Product.Where(x => x.CategoryId == categoryID).ToList();
            if (brandID != null) return context.Product.Where(x => x.BrandId == brandID).ToList();
            if (!String.IsNullOrEmpty(productType)) return context.Product.Where(x => x.ProductType.Equals(productType))
                    .ToList();
            //if (colorID != null) return context.Product.Where(x => x.ColorId == colorID).ToList();
            //if (sizeID != null) return context.Product.Where(x => x.SizeId == sizeID).ToList();

            return context.Product.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Product.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public void UpdateProduct(Product product, ProductDto productDto)
        {
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.BrandId = productDto.BrandId;
            product.CategoryId = productDto.CategoryId;
            //product.ColorId = productDto.ColorId;
            //product.SizeId = productDto.SizeId;
            product.Price = productDto.Price;
            product.Discount = productDto.Discount;
            product.IsAvailable = productDto.IsAvailable;
            product.ProductType = productDto.ProductType;
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
