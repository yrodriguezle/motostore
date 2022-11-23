using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Setting
    {
        public uint Id { get; set; }
        public string Key { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string? Value { get; set; }
        public string? Details { get; set; }
        public string Type { get; set; } = null!;
        public int Order { get; set; }
        public string? Group { get; set; }
    }
}
