﻿using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsAvailable { get; set; }
        public int? SizeId { get; set; }
        public int? ColorId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Discount { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string ProductType { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
    }
}
