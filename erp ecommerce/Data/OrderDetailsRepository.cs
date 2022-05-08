using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erp_ecommerce.Data
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ERPContext context;

        public OrderDetailsRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddOrderDetails(OrderDetails orderDetailsDto)
        {
            OrderDetails orderDetails = new OrderDetails();
            context.Add(orderDetails);
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return context.OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            return context.OrderDetails.Where(x => x.OrderDetailsId == id).FirstOrDefault();
        }

        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            context.Remove(orderDetails);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.OrderDetails.Any(x => x.OrderDetailsId == id);
        }
    }
}
