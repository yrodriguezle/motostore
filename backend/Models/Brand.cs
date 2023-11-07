using System.ComponentModel.DataAnnotations;

namespace Motostore.Models
{
    public class Brand
    {
        [Key]
        public string Make { get; set; }
        public virtual ICollection<Model> Models { get; set; }

        public Brand()
        {
            Make = string.Empty;
            Models = new List<Model>();
        }
    }
}
