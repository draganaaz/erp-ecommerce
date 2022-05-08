using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IPriceRepository
    {
        public IEnumerable<Price> GetAllPrices();

        public Price GetPriceById(int id);

        public void AddPrice(Price priceDto);

        public void UpdatePrice(Price price);

        public void DeletePrice(Price price);

        public bool SaveChanges();
    }
}
