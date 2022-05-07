using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IBrandRepository
    {
        public IEnumerable<Brand> GetAllBrands();

        public Brand GetBrandById(int id);

        public void AddBrand(Brand brandDto);

        public bool SaveChanges();
    }
}
