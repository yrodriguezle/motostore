using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Phone
    {
        public Phone()
        {
            Customers = new HashSet<Customer>();
        }

        public ulong Id { get; set; }
        public string Phone1 { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
