using erp_ecommerce.Data;
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
    }
}
