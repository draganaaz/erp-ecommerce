using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class OrderDetails
    {
        public OrderDetails()
        {
            Orders = new HashSet<Orders>();
        }

        public decimal OrderDetailsId { get; set; }
        public decimal ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
