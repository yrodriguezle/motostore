using GraphQL.Types;

using MOTOSTORE.Models;

namespace MOTOSTORE.DataAccess
{
    public class ContrattoType : ObjectGraphType<Contract>
    {
        public ContrattoType()
        {
            Description = "Contratto";
            Field(x => x.Id, type: typeof(LongGraphType), nullable: false).Description("Id");
            Field(x => x.VehicleId, type: typeof(LongGraphType), nullable: true).Description("VehicleId");
            Field(x => x.CustomerId, type: typeof(LongGraphType), nullable: true).Description("CustomerId");
            Field(x => x.RegistrationDate, type: typeof(DateTimeGraphType), nullable: true).Description("RegistrationDate");
            Field(x => x.ContractDate, type: typeof(DateTimeGraphType), nullable: true).Description("ContractDate");
            Field(x => x.GeneralCost, type: typeof(FloatGraphType), nullable: true).Description("GeneralCost");
            Field(x => x.PromotionValue, type: typeof(FloatGraphType), nullable: true).Description("PromotionValue");
            Field(x => x.PriceAgreed, type: typeof(FloatGraphType), nullable: true).Description("PriceAgreed");
            Field(x => x.AccessoriesAgreed, type: typeof(FloatGraphType), nullable: true).Description("AccessoriesAgreed");
            Field(x => x.AcquiredAgreed, type: typeof(FloatGraphType), nullable: true).Description("AcquiredAgreed");
            Field(x => x.TotalPurchase, type: typeof(FloatGraphType), nullable: true).Description("TotalPurchase");
            Field(x => x.Notes, type: typeof(StringGraphType), nullable: true).Description("Notes");
            Field(x => x.InternalNotes, type: typeof(StringGraphType), nullable: true).Description("InternalNotes");
            Field(x => x.OfficeNotes, type: typeof(StringGraphType), nullable: true).Description("OfficeNotes");
            Field(x => x.Archived, type: typeof(BooleanGraphType), nullable: true).Description("Archived");
            Field(x => x.UserId, type: typeof(IntGraphType), nullable: true).Description("UserId");
            Field(x => x.DeletedNote, type: typeof(StringGraphType), nullable: true).Description("DeletedNote");
        }
    }
}
