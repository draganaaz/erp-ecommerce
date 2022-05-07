using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ERPContext context;

        public OrderRepository(ERPContext context)
        {
            this.context = context;
        }
        public void AddOrder(Orders orderDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Orders GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
