using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Rental
    {
        public ulong Id { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public ulong? UserId { get; set; }
        public ulong? UserIdArchive { get; set; }
        public DateOnly? DataRegistrazione { get; set; }
        public DateOnly? DataRitiro { get; set; }
        public string? OraRitiro { get; set; }
        public DateOnly? DataConsegna { get; set; }
        public string? OraConsegna { get; set; }
        public int? KmAttuali { get; set; }
        public int? Percorrenza { get; set; }
        public double? ImportoCauzione { get; set; }
        public sbyte? CauzioneRestituita { get; set; }
        public string? MetodoCauzione { get; set; }
        public string? NumeroCarta { get; set; }
        public string? ScadenzaCarta { get; set; }
        public double? ImportoNoleggio { get; set; }
        public double? ImportoVersato { get; set; }
        public string? NoteNoleggio { get; set; }
        public short? Status { get; set; }
        public double? ImportoAggiuntivo { get; set; }
        public int? KmFinali { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
