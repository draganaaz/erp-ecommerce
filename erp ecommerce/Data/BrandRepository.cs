using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace erp_ecommerce.Data
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ERPContext context;

        public BrandRepository(ERPContext context)
        {
            this.context = context;
        }

        public void AddBrand(Brand brandDto)
        {
            Brand brand = new Brand();
            context.Add(brand);
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            return context.Brand.ToList();
        }

        public Brand GetBrandById(int id)
        {
            return context.Brand.Where(x => x.BrandId == id).FirstOrDefault();
        }

        public void UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void DeleteBrand(Brand brand)
        {
            context.Remove(brand);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Brand.Any(x => x.BrandId == id);
        }
    }
}
