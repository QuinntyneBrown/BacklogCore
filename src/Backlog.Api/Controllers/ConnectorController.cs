using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConnectorController
{
    private readonly IMediator _mediator;

    public ConnectorController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator);
        _mediator = mediator;
    }

    [HttpPost, DisableRequestSizeLimit]
    public async Task<ActionResult<ConnectorUploadDigitalAssetResponse>> Post()
        => await _mediator.Send(new ConnectorUploadDigitalAssetRequest());

}