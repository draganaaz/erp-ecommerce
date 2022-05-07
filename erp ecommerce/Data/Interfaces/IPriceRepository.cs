using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IPriceRepository
    {
        public IEnumerable<Price> GetAllPrices();

        public Price GetPriceById(int id);

        public void AddPrice(Price priceDto);

        public bool SaveChanges();
    }
}
