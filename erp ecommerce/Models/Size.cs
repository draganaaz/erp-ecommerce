using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class Size
    {
        public Size()
        {
            ProductSizes = new HashSet<ProductSizes>();
        }

        public decimal SizeId { get; set; }
        public string Size1 { get; set; }

        public virtual ICollection<ProductSizes> ProductSizes { get; set; }
    }
}
