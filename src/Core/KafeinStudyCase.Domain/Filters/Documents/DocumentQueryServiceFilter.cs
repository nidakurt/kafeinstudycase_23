using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Domain.Enums;

namespace KafeinStudyCase.Domain.Filters.ShippingCompanies;

public class DocumentQueryServiceFilter : IFilterModel
{
    public string Name { get; set; }
    public int Piece { get; set; }
    public double Price { get; set; }
    public StatusEnum? Status { get; set; }
}
