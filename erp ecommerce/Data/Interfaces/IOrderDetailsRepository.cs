using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IOrderDetailsRepository
    {
        public IEnumerable<OrderDetails> GetAllOrderDetails();

        public OrderDetails GetOrderDetailsById(int id);

        public void AddOrderDetails(OrderDetails orderDetails);

        public bool SaveChanges();
    }
}
