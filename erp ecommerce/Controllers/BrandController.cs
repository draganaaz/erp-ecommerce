using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandRepository brandRepository { get; }

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllBrands()
        {
            return Ok(brandRepository.GetAllBrands());
        }

        [HttpGet("{brandId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBrandById(int brandId)
        {
            Brand brand = brandRepository.GetBrandById(brandId);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult CreateBrand(Brand brand)
        {
            brandRepository.AddBrand(brand);

            try
            {
                if (!brandRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Brand.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Brand has been created.");
        }
    }
}
