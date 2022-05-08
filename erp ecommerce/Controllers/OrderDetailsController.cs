using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailsRepository orderDetailsRepository { get; }

        public OrderDetailsController(IOrderDetailsRepository orderDetailsRepository)
        {
            this.orderDetailsRepository = orderDetailsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllOrderDetails()
        {
            return Ok(orderDetailsRepository.GetAllOrderDetails());
        }

        [HttpGet("{orderDetailsId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrderDetailsById(int orderDetailsId)
        {
            OrderDetails orderDetails = orderDetailsRepository.GetOrderDetailsById(orderDetailsId);
            if (orderDetails == null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }
    }
}
