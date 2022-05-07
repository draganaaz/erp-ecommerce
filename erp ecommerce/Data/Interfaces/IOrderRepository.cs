using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IOrderRepository
    {
        public IEnumerable<Orders> GetAllOrders();

        public Orders GetOrderById(int id);

        public void AddOrder(Orders orderDto);

        public bool SaveChanges();
    }
}
