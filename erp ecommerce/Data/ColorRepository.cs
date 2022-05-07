using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public class ColorRepository : IColorRepository
    {
        private readonly ERPContext context;

        public ColorRepository(ERPContext context)
        {
            this.context = context;
        }
        public void AddColor(Color colorDto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Color> GetAllColors()
        {
            throw new NotImplementedException();
        }

        public Color GetColorById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
