using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public decimal ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsAvailable { get; set; }
        public decimal? ProductSizeId { get; set; }
        public decimal? ProductColorId { get; set; }
        public decimal? PriceId { get; set; }
        public decimal? CategoryId { get; set; }
        public decimal? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Price Price { get; set; }
        public virtual ProductColors ProductColor { get; set; }
        public virtual ProductSizes ProductSize { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
