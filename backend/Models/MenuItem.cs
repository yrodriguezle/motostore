using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class MenuItem
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public string IconClass { get; set; }
        public string Color { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public string Route { get; set; }
        public string Parameters { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
