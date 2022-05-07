using erp_ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorRepository : ControllerBase
    {
        private IColorRepository colorRepository { get; }

        public ColorRepository(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
    }
}
