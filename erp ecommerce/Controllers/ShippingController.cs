using erp_ecommerce.Data;
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
    }
}
