using erp_ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository productRepository { get; }

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
    }
}
