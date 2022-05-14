using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository { get; }
        private IBrandRepository brandRepository { get; }
        private ICategoryRepository categoryRepository { get; }
        private ISizeRepository sizeRepository { get; }
        private IColorRepository colorRepository { get; }

        public ProductController(IProductRepository productRepository, IBrandRepository brandRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.brandRepository = brandRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
#nullable enable
        public IActionResult GetAllProducts(string query = "", int categoryID = 0, int brandID = 0,
            string productType = "", int colorID = 0, int sizeID = 0, int minPrice = 0, int maxPrice = 0,
            string sortOrder = "")
        {
            // TODO: Validation (selected size, color)
            return Ok(productRepository.GetAllProducts(query, categoryID, brandID, productType,
                colorID, sizeID, minPrice, maxPrice, sortOrder));
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetProductById(int productId)
        {
            Product product = productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!brandRepository.Exists((int)product.BrandId))
            {
                return NotFound("There is no Brand with given BrandId");
            }

            if (!categoryRepository.Exists((int)product.CategoryId))
            {
                return NotFound("There is no Category with given CategoryId");
            }

            // TODO: sizes and colors
            //if (!brandRepository.Exists((int)product.BrandId))
            //{
            //    return NotFound("There is no Brand with given BrandId");
            //}

            productRepository.AddProduct(product);

            try
            {
                if (!productRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Product.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Product has been created.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct(ProductDto productDto)
        {
            // Retrieving Product entity from the database based on the passed productId
            Product product = productRepository.GetProductById(productDto.ProductId);

            // If the entity doesn't exist, we're returning a 404 error
            if (product == null)
            {
                return NotFound();
            }

            productRepository.UpdateProduct(product, productDto);

            try
            {
                if (!productRepository.SaveChanges())
                {
                    throw new Exception("Product hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Product has been updated.");
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                Product product = productRepository.GetProductById(productId);

                if (product == null)
                {
                    return NotFound();
                }

                productRepository.DeleteProduct(product);

                if (!productRepository.SaveChanges())
                {
                    throw new Exception("Product hasn't been deleted successfully.");
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }
        }
    }
}
