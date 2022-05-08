using erp_ecommerce.Data;
using erp_ecommerce.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository { get; }

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllOrders()
        {
            return Ok(orderRepository.GetAllOrders());
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetOrderById(int orderId)
        {
            Orders order = orderRepository.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
