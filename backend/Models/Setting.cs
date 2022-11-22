using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Setting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public string Details { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
        public string Group { get; set; }
    }
}
