using System.ComponentModel.DataAnnotations;

namespace Motostore.Models
{
    public class Marchi
    {
        [Key]
        public string Marchio { get; set; }
        public virtual ICollection<Modelli> Modelli { get; set; }

        public Marchi()
        {
            Marchio = string.Empty;
            Modelli = new List<Modelli>();
        }
    }
}
