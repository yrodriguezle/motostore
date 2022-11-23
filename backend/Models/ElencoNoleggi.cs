using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class ElencoNoleggi
    {
        public uint Id { get; set; }
        public int? IdClienteNoleggio { get; set; }
        public int? IdVeicoloNoleggio { get; set; }
        public DateOnly? Data { get; set; }
        public DateOnly? DataRitiro { get; set; }
        public string? OraRitiro { get; set; }
        public DateOnly? DataConsegna { get; set; }
        public string? OraConsegna { get; set; }
        public int? KmAttuali { get; set; }
        public int? Percorrenza { get; set; }
        public decimal? ImportoCauzione { get; set; }
        public string? ImportoCauzioneTxt { get; set; }
        public string? MetodoCauzione { get; set; }
        public string? CartaNumero { get; set; }
        public string? CartaScadenza { get; set; }
        public decimal? ImportoNoleggio { get; set; }
        public string? ImportoNoleggioTxt { get; set; }
        public decimal? ImportoVersato { get; set; }
        public string? ImportoVersatoTxt { get; set; }
        public string? NoteNoleggio { get; set; }
        public string? Accessori { get; set; }
    }
}
