using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Backlog.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DigitalAssetController
    {
        private readonly IMediator _mediator;

        public DigitalAssetController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("page/{pageSize}/{index}", Name = "GetDigitalAssetsPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetsPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetDigitalAssetsPageResponse>> Page([FromRoute] GetDigitalAssetsPageRequest request)
            => await _mediator.Send(request);

        [HttpGet("{digitalAssetId}", Name = "GetDigitalAssetById")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetDigitalAssetByIdResponse>> GetById([FromRoute] GetDigitalAssetByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }

            return response;
        }

        [HttpGet("range")]
        public async Task<ActionResult<GetDigitalAssetsByIdsResponse>> GetByIds([FromQuery] GetDigitalAssetsByIdsRequest request)
            => await _mediator.Send(request);

        [HttpPost("upload"), DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAssetResponse>> Save()
            => await _mediator.Send(new UploadDigitalAssetRequest());

        [AllowAnonymous]
        [HttpGet("serve/{digitalAssetId}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Serve([FromRoute] GetDigitalAssetByIdRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }


        [HttpDelete("{digitalAssetId}", Name = "RemoveDigitalAsset")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDigitalAssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDigitalAssetResponse>> Remove([FromRoute] RemoveDigitalAssetRequest request)
            => await _mediator.Send(request);
    }
}
