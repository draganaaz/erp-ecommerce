using erp_ecommerce.Entities;
using erp_ecommerce.Models;
using System.Collections.Generic;

namespace erp_ecommerce.Data
{
    public interface ISizeRepository
    {
        public IEnumerable<Size> GetAllSizes();

        public Size GetSizeById(int id);

        public void AddSize(Size sizeDto);

        public void UpdateSize(Size size, SizeDto sizeDto);

        public void DeleteSize(Size size);

        public bool SaveChanges();

        public bool Exists(int id);
    }
}
