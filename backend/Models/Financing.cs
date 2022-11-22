using System;
using System.Collections.Generic;

#nullable disable

namespace MOTOSTORE.Models
{
    public partial class Financing
    {
        public long Id { get; set; }
        public long ContractId { get; set; }
        public long UserId { get; set; }
        public string IbanBanca { get; set; }
        public string StatoCivile { get; set; }
        public int? Figli { get; set; }
        public bool? CasaDiProprieta { get; set; }
        public string Residenza { get; set; }
        public double? CostoAffitto { get; set; }
        public string DaQuanto { get; set; }
        public string PrecedenteSe5Anni { get; set; }
        public bool? Dipendente { get; set; }
        public string NomeAzienda { get; set; }
        public DateTime? InizioAttivitaAssunzione { get; set; }
        public string TelefonoAzienda { get; set; }
        public bool? Approvato { get; set; }
        public long? UserIdApprovazione { get; set; }
        public DateTime? DataApprovazione { get; set; }
        public string PartnerNome { get; set; }
        public string PartnerLuogoNascita { get; set; }
        public DateTime? PartnerDataNascita { get; set; }
        public string PartnerImpiego { get; set; }
        public DateTime? PartnerDataAssunzione { get; set; }
        public double? PartnerStipendio { get; set; }
        public string Occupazione { get; set; }
    }
}
