using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Phone
    {
        public Phone()
        {
            CustomersPhones = new HashSet<CustomersPhone>();
        }

        public long Id { get; set; }
        public string Phone1 { get; set; }

        public virtual ICollection<CustomersPhone> CustomersPhones { get; set; }
    }
}
