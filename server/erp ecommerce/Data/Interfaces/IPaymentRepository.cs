using erp_ecommerce.Models;

namespace erp_ecommerce.Data
{
    public interface IPaymentRepository
    {
        public void AddPayment(PaymentDto paymentDto);

        public bool SaveChanges();
    }
}
