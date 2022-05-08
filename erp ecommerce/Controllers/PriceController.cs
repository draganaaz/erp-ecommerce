using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private IPriceRepository priceRepository { get; }

        public PriceController(IPriceRepository priceRepository)
        {
            this.priceRepository = priceRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllPrices()
        {
            return Ok(priceRepository.GetAllPrices());
        }

        [HttpGet("{priceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPriceById(int priceId)
        {
            Price price= priceRepository.GetPriceById(priceId);
            if (price == null)
            {
                return NotFound();
            }
            return Ok(price);
        }
    }
}
