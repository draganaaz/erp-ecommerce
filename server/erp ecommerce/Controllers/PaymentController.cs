using erp_ecommerce.Data;
using erp_ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace erp_ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentRepository paymentRepository { get; }

        public PaymentController(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;

        }
        //[Authorize(Roles = UserRoles.User)]
        [HttpPost]
        public IActionResult CreatePayment(PaymentDto paymentDto)
        {
            paymentRepository.AddPayment(paymentDto);

            try
            {
                if (!paymentRepository.SaveChanges())
                {
                    throw new Exception("Error has occured during the creation of Payment.");
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has occured. Check logs for details.");
            }

            return Ok("Payment has been created.");
        }
    }
}
