using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public class PriceRepository : IPriceRepository
    {
        private readonly ERPContext context;

        public PriceRepository(ERPContext context)
        {
            this.context = context;
        }
        public void AddPrice(Price priceDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Price> GetAllPrices()
        {
            throw new NotImplementedException();
        }

        public Price GetPriceById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
