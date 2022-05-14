using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Size size = new Size();
            context.Add(size);
        }

        public IEnumerable<Size> GetAllSizes()
        {
            return context.Size.ToList();
        }

        public Size GetSizeById(int id)
        {
            return context.Size.Where(x => x.SizeId == id).FirstOrDefault();
        }

        public void UpdateSize(Size size, SizeDto sizeDto)
        {
            size.Size1 = sizeDto.Size;
        }

        public void DeleteSize(Size size)
        {
            context.Remove(size);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Size.Any(x => x.SizeId == id);
        }
    }
}
