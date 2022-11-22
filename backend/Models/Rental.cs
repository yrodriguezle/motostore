using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Rental
    {
        public long Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public long? UserId { get; set; }
        public long? UserIdArchive { get; set; }
        public DateTime? DataRegistrazione { get; set; }
        public DateTime? DataRitiro { get; set; }
        public string OraRitiro { get; set; }
        public DateTime? DataConsegna { get; set; }
        public string OraConsegna { get; set; }
        public int? KmAttuali { get; set; }
        public int? Percorrenza { get; set; }
        public double? ImportoCauzione { get; set; }
        public byte? CauzioneRestituita { get; set; }
        public string MetodoCauzione { get; set; }
        public string NumeroCarta { get; set; }
        public string ScadenzaCarta { get; set; }
        public double? ImportoNoleggio { get; set; }
        public double? ImportoVersato { get; set; }
        public string NoteNoleggio { get; set; }
        public short? Status { get; set; }
        public double? ImportoAggiuntivo { get; set; }
        public int? KmFinali { get; set; }
    }
}
