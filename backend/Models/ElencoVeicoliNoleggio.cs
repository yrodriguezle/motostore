using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class ElencoVeicoliNoleggio
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modello { get; set; }
        public int? Cilindrata { get; set; }
        public string Colore { get; set; }
        public string Targa { get; set; }
        public string Telaio { get; set; }
        public string Intestazione { get; set; }
        public DateTime? DataImmatricolazione { get; set; }
        public string Assicurazione { get; set; }
        public DateTime? AssicurazioneScadenza { get; set; }
        public string StatoVeicolo { get; set; }
    }
}
