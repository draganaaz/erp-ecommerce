using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class Orders
    {
        public decimal OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateShipped { get; set; }
        public string Status { get; set; }
        public decimal OrderDetailsId { get; set; }
        public decimal CustomerId { get; set; }
        public decimal ShippingId { get; set; }

        public virtual Users Customer { get; set; }
        public virtual OrderDetails OrderDetails { get; set; }
        public virtual Shipping Shipping { get; set; }
    }
}
