using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motostore.Models
{
    public class Company
    {
        [Key]
        public string CompanyCode { get; set; }
        

        [ForeignKey("CompanyCodeOwner")]
        public virtual ICollection<Company> Companies { get; set; }

        public Company()
        {
            CompanyCode = string.Empty;
            Companies = new List<Company>();
        }
    }
}
