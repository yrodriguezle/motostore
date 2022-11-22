using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class CustomersPhone
    {
        public long CustomerId { get; set; }
        public long PhoneId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
