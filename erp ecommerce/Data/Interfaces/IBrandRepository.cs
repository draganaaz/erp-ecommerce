using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IBrandRepository
    {
        public IEnumerable<Brand> GetAllBrands();

        public Brand GetBrandById(int id);

        public void AddBrand(Brand brand);

        public void UpdateBrand(Brand brand, BrandDto brandDto);

        public void DeleteBrand(Brand brand);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
