using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Price
    {
        public Price()
        {
            Product = new HashSet<Product>();
        }

        public decimal PriceId { get; set; }
        public decimal Price1 { get; set; }
        public decimal? Discount { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
