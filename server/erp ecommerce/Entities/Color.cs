using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Color
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColors>();
        }

        public int ColorId { get; set; }
        public string ColorName { get; set; }

        public virtual ICollection<ProductColors> ProductColors { get; set; }
    }
}
