using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Color
    {
        public Color()
        {
            Product = new HashSet<Product>();
        }

        public int ColorId { get; set; }
        public string Color1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
