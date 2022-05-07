using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ERPContext context;

        public OrderDetailsRepository(ERPContext context)
        {
            this.context = context;
        }
        public void AddOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            throw new NotImplementedException();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
