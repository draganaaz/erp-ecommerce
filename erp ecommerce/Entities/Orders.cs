using System;

namespace erp_ecommerce.Entities
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsPaymentDone { get; set; }
    }
}
