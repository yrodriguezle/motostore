using System.ComponentModel.DataAnnotations.Schema;

namespace Motostore.Models
{
    public class Modelli
    {
        public string Modello { get; set; }
        public string Marchio { get; set; }
        [ForeignKey("Marchio")]
        public virtual Marchi MarchiMarchio { get; set; }

        public Modelli()
        {
            Modello = string.Empty;
            Marchio = string.Empty;
            MarchiMarchio = new Marchi();
        }
    }
}
