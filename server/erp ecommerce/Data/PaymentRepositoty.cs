using erp_ecommerce.Entities;
using erp_ecommerce.Models;

namespace erp_ecommerce.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ERPContext context;

        public PaymentRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddPayment(PaymentDto paymentDto)
        {
            throw new System.NotImplementedException();
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

    }
}
