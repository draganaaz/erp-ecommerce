using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erp_ecommerce.Data
{
    public class ShippingRepository : IShippingRepository
    {
        private readonly ERPContext context;

        public ShippingRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddShipping(Shipping shippingDto)
        {
            Shipping shipping = new Shipping();
            context.Add(shipping);
        }

        public IEnumerable<Shipping> GetAllShippings()
        {
            return context.Shipping.ToList();
        }

        public Shipping GetShippingById(int id)
        {
            return context.Shipping.Where(x => x.ShippingId == id).FirstOrDefault();
        }

        public void UpdateShipping(Shipping shipping)
        {
            throw new NotImplementedException();
        }

        public void DeleteShipping(Shipping shipping)
        {
            context.Remove(shipping);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Shipping.Any(x => x.ShippingId == id);
        }
    }
}
