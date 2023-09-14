using KafeinStudyCase.Core.Data.Concrete;
using KafeinStudyCase.Application.Core.Persistence.UoW;
using KafeinStudyCase.Persistence.Context;

namespace KafeinStudyCase.Persistence.UoW;

public class DocumentUnitOfWork : UnitOfWork<DocumentDbContext>, IDocumentUnitOfWork
{
    public DocumentUnitOfWork(DocumentDbContext dbContext) : base(dbContext)
    {
    }
}