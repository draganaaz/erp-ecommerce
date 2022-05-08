using erp_ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Color color = new Color();
            context.Add(color);
        }

        public IEnumerable<Color> GetAllColors()
        {
            return context.Color.ToList();
        }

        public Color GetColorById(int id)
        {
            return context.Color.Where(x => x.ColorId == id).FirstOrDefault();
        }

        public void UpdateColor(Color color)
        {
            throw new NotImplementedException();
        }

        public void DeleteColor(Color color)
        {
            context.Remove(color);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public bool Exists(int id)
        {
            return context.Color.Any(x => x.ColorId == id);
        }
    }
}
