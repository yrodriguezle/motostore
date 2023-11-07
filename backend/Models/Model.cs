using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Motostore.Models
{
    public class Model
    {
        [Key]
        public string ModelName { get; set; }
        public string Brand { get; set; }
        [ForeignKey("Marchio")]
        public virtual Brand FBrand { get; set; }

        public Model()
        {
            ModelName = string.Empty;
            Brand = string.Empty;
            FBrand = new Brand();
        }
    }
}
