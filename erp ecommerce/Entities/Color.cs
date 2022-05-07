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

        public decimal ColorId { get; set; }
        public string Color1 { get; set; }

        public virtual ICollection<ProductColors> ProductColors { get; set; }
    }
}
