using System;
using System.Collections.Generic;

namespace Motostore.Models
{
    public partial class Financing
    {
        public ulong Id { get; set; }
        public ulong ContractId { get; set; }
        public ulong UserId { get; set; }
        public string IbanBanca { get; set; } = null!;
        public string? StatoCivile { get; set; }
        public int? Figli { get; set; }
        public bool? CasaDiProprieta { get; set; }
        public string? Residenza { get; set; }
        public double? CostoAffitto { get; set; }
        public string? DaQuanto { get; set; }
        public string? PrecedenteSe5Anni { get; set; }
        public bool? Dipendente { get; set; }
        public string? NomeAzienda { get; set; }
        public DateOnly? InizioAttivitaAssunzione { get; set; }
        public string? TelefonoAzienda { get; set; }
        public bool? Approvato { get; set; }
        public long? UserIdApprovazione { get; set; }
        public DateOnly? DataApprovazione { get; set; }
        public string? PartnerNome { get; set; }
        public string? PartnerLuogoNascita { get; set; }
        public DateOnly? PartnerDataNascita { get; set; }
        public string? PartnerImpiego { get; set; }
        public DateOnly? PartnerDataAssunzione { get; set; }
        public double? PartnerStipendio { get; set; }
        public string? Occupazione { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
