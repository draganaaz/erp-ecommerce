using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class ProductSizes
    {
        public int ProductSizeId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}
