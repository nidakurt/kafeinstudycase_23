using KafeinStudyCase.Application.Core.Persistence.Repositories.ShippingCompanies;
using KafeinStudyCase.Core.Data.Concrete;
using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Domain.Filters.ShippingCompanies;
using KafeinStudyCase.Persistence.Context;
using static KafeinStudyCase.Application.Constants.Constants;

namespace KafeinStudyCase.Persistence.Repositories.ShippingCompanies;

public class DocumentRepository : Repository<Domain.Entities.Document, DocumentDbContext>, IDocumentRepository
{
    public DocumentRepository(DocumentDbContext dbContext) : base(dbContext)
    {
    }
}

