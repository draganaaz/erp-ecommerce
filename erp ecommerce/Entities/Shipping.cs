using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Shipping
    {
        public Shipping()
        {
            Orders = new HashSet<Orders>();
        }

        public decimal ShippingId { get; set; }
        public string ShippingType { get; set; }
        public string ShippingCost { get; set; }
        public string ShippingRegion { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
