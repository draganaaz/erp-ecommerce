using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Price price = new Price();
            context.Add(price);
        }

        public IEnumerable<Price> GetAllPrices()
        {
            return context.Price.ToList();
        }

        public Price GetPriceById(int id)
        {
            return context.Price.Where(x => x.PriceId == id).FirstOrDefault();
        }

        public void UpdatePrice(Price price)
        {
            throw new NotImplementedException();
        }

        public void DeletePrice(Price price)
        {
            context.Remove(price);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Price.Any(x => x.PriceId == id);
        }
    }
}
