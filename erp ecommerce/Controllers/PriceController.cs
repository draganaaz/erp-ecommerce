using erp_ecommerce.Data;
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
    }
}
