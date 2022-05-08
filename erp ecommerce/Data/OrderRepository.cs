using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Orders order = new Orders();
            context.Add(order);
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public Orders GetOrderById(int id)
        {
            return context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }

        public void UpdateOrder(Orders order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Orders order)
        {
            context.Remove(order);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Orders.Any(x => x.OrderId == id);
        }
    }
}
