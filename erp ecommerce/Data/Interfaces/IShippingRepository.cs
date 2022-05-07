using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IShippingRepository
    {
        public IEnumerable<Shipping> GetAllShippings();

        public Product GetShippingById(int id);

        public void AddShipping(Shipping shippingDto);

        public bool SaveChanges();
    }
}
