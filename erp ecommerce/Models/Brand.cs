using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Product = new HashSet<Product>();
        }

        public decimal BrandId { get; set; }
        public string Brand1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
