using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using JWTAuthentication.Authentication;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = UserRoles.Admin)]
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

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateBrand(BrandDto brandDto)
        {
            // Retrieving Brand entity from the database based on the passed brandId
            Brand brand = brandRepository.GetBrandById(brandDto.BrandId);

            // If the entity doesn't exist, we're returning a 404 error
            if (brand == null)
            {
                return NotFound();
            }

            brandRepository.UpdateBrand(brand, brandDto);

            try
            {
                if (!brandRepository.SaveChanges())
                {
                    throw new Exception("Brand hasn't been updated successfully.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Brand has been updated.");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{brandId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteBrand(int brandId)
        {
            try
            {
                Brand brand = brandRepository.GetBrandById(brandId);

                if (brand == null)
                {
                    return NotFound();
                }

                brandRepository.DeleteBrand(brand);

                if (!brandRepository.SaveChanges())
                {
                    throw new Exception("Brand hasn't been deleted successfully.");
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
