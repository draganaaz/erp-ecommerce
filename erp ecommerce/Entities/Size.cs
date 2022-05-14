using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Size
    {
        public Size()
        {
            Product = new HashSet<Product>();
        }

        public int SizeId { get; set; }
        public string Size1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
