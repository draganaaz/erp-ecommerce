using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductColors = new HashSet<ProductColors>();
            ProductSizes = new HashSet<ProductSizes>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsAvailable { get; set; }
        public int? ProductSizeId { get; set; }
        public int? ProductColorId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ProductType { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductColors> ProductColors { get; set; }
        public virtual ICollection<ProductSizes> ProductSizes { get; set; }
    }
}
