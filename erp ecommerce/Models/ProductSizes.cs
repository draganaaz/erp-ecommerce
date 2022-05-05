using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class ProductSizes
    {
        public ProductSizes()
        {
            Product = new HashSet<Product>();
        }

        public decimal ProductSizeId { get; set; }
        public decimal ProductId { get; set; }
        public decimal SizeId { get; set; }

        public virtual Size Size { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
