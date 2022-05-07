using erp_ecommerce.Data;
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
    }
}
