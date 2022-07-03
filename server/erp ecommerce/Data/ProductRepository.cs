using erp_ecommerce.Entities;
using erp_ecommerce.Filters;
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

        public void AddProduct(ProductDto productDto)
        {
            Product product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Discount = productDto.Discount,
                BrandId = productDto.BrandId,
                CategoryId = productDto.CategoryId,
                IsAvailable = productDto.IsAvailable,
                Image = productDto.Image,
                ProductType = productDto.ProductType
            };
            context.Add(product);
        }

#nullable enable
        public PagedResponse<List<Product>> GetAllProducts(string? query, int? categoryID, int? brandID,
            string? productType, int? colorID, int? sizeID, int? minPrice, int? maxPrice, 
            string? sortOrder, int pageNumber, int pageSize)
        {
            var validFilter = new PaginationFilter(pageNumber, pageSize);
            int totalRecords = context.Product.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            // Pagination and including product sizes and colors
            var products = context.Product
                .Skip((validFilter.PageNumber- 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .Include(x => x.ProductColors).ThenInclude(color => color.Color)
                .Include(x => x.ProductSizes).ThenInclude(size => size.Size).ToList();


            // Search bar, case insensitive filtering
            if (!String.IsNullOrEmpty(query))
                return new PagedResponse<List<Product>>(products.Where(x => x.Name.ToLower().Contains(query.ToLower())
                    || x.Description.ToLower().Contains(query.ToLower())).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);

            // Sorting
            if (!String.IsNullOrEmpty(sortOrder))
            {
                return sortOrder switch
                {
                    "availability" => new PagedResponse<List<Product>>(products.OrderBy(x => x.IsAvailable).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages),
                    "price" => new PagedResponse<List<Product>>(products.OrderBy(x => x.Price).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages),
                    "price_desc" => new PagedResponse<List<Product>>(products.OrderByDescending(x => x.Price).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages),
                    "dicount_desc" => new PagedResponse<List<Product>>(products.OrderByDescending(x => x.Discount).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages),
                   _ => new PagedResponse<List<Product>>(products.OrderBy(x => x.Discount).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages)
                };
            }


            #region Filters
            if (categoryID != null)
            {
                return new PagedResponse<List<Product>>(products.Where(x => x.CategoryId == categoryID).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            if (brandID != null)
            {
                return new PagedResponse<List<Product>>(products.Where(x => x.BrandId == brandID).ToList()
                   , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            if (!String.IsNullOrEmpty(productType))
            {
                return new PagedResponse<List<Product>>(products.Where(x => x.ProductType.ToLower().Equals(productType.ToLower())).ToList()
                    , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            if (minPrice != null && maxPrice != null)
            {
                return new PagedResponse<List<Product>>(products.Where(x => (int?)x.Price > minPrice && (int?)x.Price < maxPrice).ToList()
                    , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            if (colorID != null)
            {
                return new PagedResponse<List<Product>>(products.Where(x => x.ProductColors.Any(y => y.ColorId == colorID)).ToList()
                    , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            if (sizeID != null)
            {
                return new PagedResponse<List<Product>>(products.Where(x => x.ProductSizes.Any(y => y.SizeId == sizeID)).ToList()
                    , validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
            }

            #endregion

            return new PagedResponse<List<Product>>(products, validFilter.PageNumber, validFilter.PageSize, totalRecords, totalPages);
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
