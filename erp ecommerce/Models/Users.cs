using System;
using System.Collections.Generic;

namespace erp_ecommerce.Models
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public decimal UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
