using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
