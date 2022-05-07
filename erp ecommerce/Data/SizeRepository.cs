using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ERPContext context;

        public SizeRepository(ERPContext context)
        {
            this.context = context;
        }
        public void AddSize(Size sizeDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Size> GetAllSizes()
        {
            throw new NotImplementedException();
        }

        public Size GetSizeById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
