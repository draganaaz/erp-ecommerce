using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private IShippingRepository shippingRepository { get; }

        public ShippingController(IShippingRepository shippingRepository)
        {
            this.shippingRepository = shippingRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllShippings()
        {
            return Ok(shippingRepository.GetAllShippings());
        }

        [HttpGet("{shippingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetShippingById(int shippingId)
        {
            Shipping shipping = shippingRepository.GetShippingById(shippingId);
            if (shipping == null)
            {
                return NotFound();
            }
            return Ok(shipping);
        }
    }
}
