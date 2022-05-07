using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class ProductColors
    {
        public ProductColors()
        {
            Product = new HashSet<Product>();
        }

        public decimal ProductColorId { get; set; }
        public decimal ProductId { get; set; }
        public decimal ColorId { get; set; }

        public virtual Color Color { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
