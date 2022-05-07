using erp_ecommerce.Data;
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
    }
}
