using erp_ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private IBrandRepository brandRepository { get; }

        public BrandController(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
    }
}
