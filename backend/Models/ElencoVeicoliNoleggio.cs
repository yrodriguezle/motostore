using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ElencoVeicoliNoleggio
    {
        public uint Id { get; set; }
        public string? Marca { get; set; }
        public string? Modello { get; set; }
        public int? Cilindrata { get; set; }
        public string? Colore { get; set; }
        public string? Targa { get; set; }
        public string? Telaio { get; set; }
        public string? Intestazione { get; set; }
        public DateOnly? DataImmatricolazione { get; set; }
        public string? Assicurazione { get; set; }
        public DateOnly? AssicurazioneScadenza { get; set; }
        public string? StatoVeicolo { get; set; }
    }
}
