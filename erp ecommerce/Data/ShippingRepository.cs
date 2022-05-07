using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Shipping> GetAllShippings()
        {
            throw new NotImplementedException();
        }

        public Product GetShippingById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
