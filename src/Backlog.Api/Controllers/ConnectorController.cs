using Backlog.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectorController
    {
        private readonly IMediator _mediator;

        public ConnectorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAsset.Response>> Post()
            => await _mediator.Send(new UploadDigitalAsset.Request());

    }
}
