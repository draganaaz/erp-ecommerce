using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IOrderRepository
    {
        public IEnumerable<Orders> GetAllOrders();

        public Orders GetOrderById(int id);

        public void AddOrder(Orders orderDto);

        public void UpdateOrder(Orders order, OrderDto orderDto);

        public void DeleteOrder(Orders order);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
