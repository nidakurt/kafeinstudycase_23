using Microsoft.AspNetCore.Mvc;
using KafeinStudyCase.Core.Base.Api;
using KafeinStudyCase.Core.Base.Handlers;
using KafeinStudyCase.Application.Handlers.ShippingCompanies.Commands;

namespace KafeinStudyCase.API.Controllers;
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/documents")]
[ApiController]
public class DocumentController : BaseApiController
{
    private readonly IRequestBus _requestBus;

    public DocumentController(IRequestBus requestBus)
    {
        _requestBus = requestBus;
    }
    /// <summary>
    /// creates shipping company
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateDocument([FromBody] CreateDocumentCommand createDocumentCommand) => StatusCode(StatusCodes.Status200OK, await _requestBus.Send(createDocumentCommand)); // Ok(await mediator.Send(createDocumentCommand));

}
