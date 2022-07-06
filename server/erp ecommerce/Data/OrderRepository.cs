using erp_ecommerce.Entities;
using erp_ecommerce.Models;
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

        public void AddOrder(OrderDto orderDto)
        {
            Orders orderToSave = new Orders
            {
                Name = orderDto.Name,
                Address = orderDto.Address,
                City = orderDto.City,
                Country = orderDto.Country,
                TotalPrice = orderDto.TotalPrice,
                DateCreated = DateTime.Now,
                IsPaymentDone = false
            };
            context.Add(orderToSave);
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return context.Orders.ToList();
        }

        public Orders GetOrderById(int id)
        {
            return context.Orders.Where(x => x.OrderId == id).FirstOrDefault();
        }

        public void UpdateOrder(Orders order, OrderDto orderDto)
        {
            order.Name = orderDto.Name;
            order.Address = orderDto.Address;
            order.City = orderDto.City;
            order.Country = orderDto.Country;
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
