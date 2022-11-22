using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class DataType
    {
        public DataType()
        {
            DataRows = new HashSet<DataRow>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string DisplayNameSingular { get; set; }
        public string DisplayNamePlural { get; set; }
        public string Icon { get; set; }
        public string ModelName { get; set; }
        public string PolicyName { get; set; }
        public string Controller { get; set; }
        public string Description { get; set; }
        public bool GeneratePermissions { get; set; }
        public byte ServerSide { get; set; }
        public string Details { get; set; }

        public virtual ICollection<DataRow> DataRows { get; set; }
    }
}
