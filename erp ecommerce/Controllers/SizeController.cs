using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        private ISizeRepository sizeRepository { get; }

        public SizeController(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllSizes()
        {
            return Ok(sizeRepository.GetAllSizes());
        }

        [HttpGet("{sizeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetSizeById(int sizeId)
        {
            Size size= sizeRepository.GetSizeById(sizeId);
            if (size == null)
            {
                return NotFound();
            }
            return Ok(size);
        }

    }
}
