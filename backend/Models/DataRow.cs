using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class DataRow
    {
        public int Id { get; set; }
        public int DataTypeId { get; set; }
        public string Field { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public bool Required { get; set; }
        public bool? Browse { get; set; }
        public bool? Read { get; set; }
        public bool? Edit { get; set; }
        public bool? Add { get; set; }
        public bool? Delete { get; set; }
        public string Details { get; set; }
        public int Order { get; set; }

        public virtual DataType DataType { get; set; }
    }
}
