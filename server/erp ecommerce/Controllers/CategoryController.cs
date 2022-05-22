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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository { get; }

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllCategories()
        {
            return Ok(categoryRepository.GetAllCategories());
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetCategoryById(int categoryId)
        {
            Category category = categoryRepository.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            categoryRepository.AddCategory(category);

            try
            {
                if (!categoryRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Category.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Category has been created.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCategory(CategoryDto categoryDto)
        {
            // Retrieving Category entity from the database based on the passed categoryId
            Category category = categoryRepository.GetCategoryById(categoryDto.CategoryId);

            // If the entity doesn't exist, we're returning a 404 error
            if (category == null)
            {
                return NotFound();
            }

            categoryRepository.UpdateCategory(category, categoryDto);

            try
            {
                if (!categoryRepository.SaveChanges())
                {
                    throw new Exception("Category hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Category has been updated.");
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                Category category = categoryRepository.GetCategoryById(categoryId);

                if (category == null)
                {
                    return NotFound();
                }

                categoryRepository.DeleteCategory(category);

                if (!categoryRepository.SaveChanges())
                {
                    throw new Exception("Category hasn't been deleted successfully.");
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
