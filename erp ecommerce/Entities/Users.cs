﻿using System;
using System.Collections.Generic;

namespace erp_ecommerce.Entities
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
