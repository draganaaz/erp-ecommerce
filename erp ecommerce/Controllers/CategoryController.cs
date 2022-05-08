using erp_ecommerce.Data;
using erp_ecommerce.Entities;
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
    }
}
