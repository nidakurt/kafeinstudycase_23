using AutoMapper;
using KafeinStudyCase.Core.Base.Wrapper;
using KafeinStudyCase.Core.Data.Models;
using KafeinStudyCase.Core.ExceptionHandling.Exceptions;
using KafeinStudyCase.Application.Core.Infrastructure.Document.Document;
using KafeinStudyCase.Application.Core.Persistence.Repositories.ShippingCompanies;
using KafeinStudyCase.Application.Core.Persistence.UoW;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.Commands;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.DTOs;
using KafeinStudyCase.Domain.Exceptions;
using KafeinStudyCase.Domain.Filters.ShippingCompanies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;

namespace KafeinStudyCase.Infrastructure.Document.ShippingCompanies;

public class DocumentService : IDocumentService
{
    private readonly IMapper _mapper;
    private readonly IDocumentRepository _documentRepository;
    private readonly IDocumentUnitOfWork _documentUnitOfWork;

    public DocumentService(IMapper mapper, IDocumentRepository DocumentRepository, IDocumentUnitOfWork DocumentUnitOfWork)
    {
        _mapper = mapper;
        _documentRepository = DocumentRepository;
        _documentUnitOfWork = DocumentUnitOfWork;
    }


    public async Task<DocumentDTO> AddAsync(CreateDocumentCommand model, CancellationToken cancellationToken)
    {
        var DocumentEntity = _mapper.Map<Domain.Entities.Document>(model);
        await _documentRepository.AddAsync(DocumentEntity, cancellationToken);

        string newDocName = Guid.NewGuid().ToString();
        PdfWriter writer = new PdfWriter("\\"+ newDocName + ".pdf");
        PdfDocument pdf = new PdfDocument(writer);
        iText.Layout.Document document = new iText.Layout.Document(pdf);


        Table table = new Table(2, false);
        Cell cell11 = new Cell(1, 1)
           .SetBackgroundColor(ColorConstants.GRAY)
           .SetTextAlignment(TextAlignment.CENTER)
           .Add(new Paragraph(model.Name));
        Cell cell12 = new Cell(1, 1)
           .SetBackgroundColor(ColorConstants.GRAY)
           .SetTextAlignment(TextAlignment.CENTER)
           .Add(new Paragraph(model.Piece.ToString()));

        Cell cell21 = new Cell(1, 1)
           .SetTextAlignment(TextAlignment.CENTER)
           .Add(new Paragraph(model.Price.ToString()));

        Cell cell22 = new Cell(1, 1)
          .SetTextAlignment(TextAlignment.CENTER)
          .Add(new Paragraph((model.Piece*model.Price).ToString()));

        table.AddCell(cell11);
        table.AddCell(cell12);
        table.AddCell(cell21);
        table.AddCell(cell22);

        document.Add(table);

        document.Close();

        byte[] bytes = System.IO.File.ReadAllBytes("\\" + newDocName + ".pdf");

        DocumentDTO generatedDocument = new DocumentDTO();
        generatedDocument.Name = newDocName + "pdf";
        generatedDocument.File = bytes;
        await _documentUnitOfWork.CommitAsync(cancellationToken);



        return _mapper.Map<DocumentDTO>(DocumentEntity);
    }

}
