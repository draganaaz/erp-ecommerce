using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IShippingRepository
    {
        public IEnumerable<Shipping> GetAllShippings();

        public Shipping GetShippingById(int id);

        public void AddShipping(Shipping shippingDto);

        public void UpdateShipping(Shipping shiping);

        public void DeleteShipping(Shipping shipping);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
