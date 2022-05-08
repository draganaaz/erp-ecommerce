using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorRepository : ControllerBase
    {
        private IColorRepository colorRepository { get; }

        public ColorRepository(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllColors()
        {
            return Ok(colorRepository.GetAllColors());
        }

        [HttpGet("{colorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetColorById(int colorId)
        {
            Color color = colorRepository.GetColorById(colorId);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }
    }
}
