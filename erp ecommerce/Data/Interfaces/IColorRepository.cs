using erp_ecommerce.Entities;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface IColorRepository
    {
        public IEnumerable<Color> GetAllColors();

        public Color GetColorById(int id);

        public void AddColor(Color colorDto);

        public void UpdateColor(Color color);

        public void DeleteColor(Color color);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
