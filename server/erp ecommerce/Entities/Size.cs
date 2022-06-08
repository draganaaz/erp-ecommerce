using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSizes>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }

        public virtual ICollection<ProductSizes> ProductSizes { get; set; }
    }
}
