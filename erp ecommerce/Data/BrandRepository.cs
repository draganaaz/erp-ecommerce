using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            throw new NotImplementedException();
        }

        public Brand GetBrandById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
