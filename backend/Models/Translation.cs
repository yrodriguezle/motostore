using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Translation
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int ForeignKey { get; set; }
        public string Locale { get; set; }
        public string Value { get; set; }
    }
}
