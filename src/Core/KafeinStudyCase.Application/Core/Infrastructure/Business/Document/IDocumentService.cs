using KafeinStudyCase.Application.Handlers.BaseResponses;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.Commands;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;
using KafeinStudyCase.Core.Base.IoC;
using KafeinStudyCase.Core.Base.Wrapper;
using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Domain.Filters.ShippingCompanies;

namespace KafeinStudyCase.Application.Core.Infrastructure.Document.Document;

public interface IDocumentService : IScopedService
{
    Task<DocumentDTO> AddAsync(CreateDocumentCommand model, CancellationToken cancellationToken);
}
