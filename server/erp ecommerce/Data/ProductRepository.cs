using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<Product> GetAllProducts(string? query, int? categoryID, int? brandID,
            string? productType, int? colorID, int? sizeID, int? minPrice, int? maxPrice, 
            string? sortOrder, int pageNumber, int pageSize)
        {
            var pgNumber = pageNumber < 1 ? 1 : pageNumber;
            var pgSize = pageSize > 10 ? 10 : pageSize;

            // Pagination and including product sizes and colors
            var product = context.Product
                .Skip((pgNumber - 1) * pgSize)
                .Take(pgSize)
                .Include(x => x.ProductColors).ThenInclude(color => color.Color)
                .Include(x => x.ProductSizes).ThenInclude(size => size.Size).ToList();


            // Search bar, case insensitive filtering
            if (!String.IsNullOrEmpty(query))
                return product.Where(x => x.Name.ToLower().Contains(query.ToLower()) 
                    || x.Description.ToLower().Contains(query.ToLower()));

            // Sorting
            if (!String.IsNullOrEmpty(sortOrder))
            {
                return sortOrder switch
                {
                    "name_desc" => product.OrderByDescending(x => x.Name),
                    "price" => product.OrderBy(x => x.Price),
                    "price_desc" => product.OrderByDescending(x => x.Price),
                    _ => product.OrderBy(x => x.Name),
                };
            }


            #region Filters
            if (categoryID != null)
            {
                return product.Where(x => x.CategoryId == categoryID).ToList();
            }

            if (brandID != null)
            {
                return product.Where(x => x.BrandId == brandID).ToList();
            }

            if (!String.IsNullOrEmpty(productType))
            {
                return product.Where(x => x.ProductType.Equals(productType)).ToList();
            }

            if (minPrice != null && maxPrice != null)
            {
                return product.Where(x => (int?)x.Price > minPrice && (int?)x.Price < maxPrice).ToList();
            }

            if (colorID != null)
            {
                return product.Where(x => x.ProductColors.Any(y => y.ColorId == colorID)).ToList();
            }

            if (sizeID != null)
            {
                return product.Where(x => x.ProductSizes.Any(y => y.SizeId == sizeID)).ToList();
            }

            #endregion
            return product.ToList();
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
