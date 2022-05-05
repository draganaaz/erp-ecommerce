using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class Category
    {
        public Category()
        {
            Product = new HashSet<Product>();
        }

        public decimal CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
