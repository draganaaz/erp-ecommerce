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

        public void AddOrder(Orders order)
        {
            Orders orderToSave = new Orders
            {
                Name = order.Name,
                Surname = order.Surname,
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                DateCreated = DateTime.Now,
                IsPaymentDone = order.IsPaymentDone,
                TotalPrice = order.TotalPrice
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
            order.Surname = orderDto.Surname;
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
