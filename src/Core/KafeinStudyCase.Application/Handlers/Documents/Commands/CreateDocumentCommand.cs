using Microsoft.Extensions.Options;
using KafeinStudyCase.Core.Base.Handlers;
using KafeinStudyCase.Application.Core.Infrastructure.Document.Document;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;
using KafeinStudyCase.Domain.Enums;

namespace KafeinStudyCase.Application.Handlers.ShippingCompanies.Commands;

public class CreateDocumentCommand : ICommand<DocumentDTO>
{
    public string Name { get; set; }
    public int Piece { get; set; }
    public double Price { get; set; }
    public StatusEnum? Status { get; set; }
}
public sealed class CreateDocumentCommandHandler : BaseCommandHandler<CreateDocumentCommand, DocumentDTO>
{
    private readonly IDocumentService _DocumentService;
    public CreateDocumentCommandHandler(IDocumentService DocumentService)
    {
        _DocumentService = DocumentService;
    }

    public override async Task<DocumentDTO> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        return await _DocumentService.AddAsync(request, cancellationToken);
    }
}
