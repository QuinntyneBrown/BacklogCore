using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<GetDigitalAssetsPageResponse>> Page([FromRoute] int pageSize, [FromRoute] int index)
        {
            var request = new GetDigitalAssetsPageRequest { Index = index, PageSize = pageSize };

            return await _mediator.Send(request);
        }

        [HttpGet("{digitalAssetId}", Name = "GetDigitalAssetById")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetDigitalAssetByIdResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<GetDigitalAssetByIdResponse>> GetById([FromRoute] Guid digitalAssetId)
        {
            var request = new GetDigitalAssetByIdRequest {  DigitalAssetId = digitalAssetId };

            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
            {
                return new NotFoundObjectResult(request.DigitalAssetId);
            }

            return response;
        }

        [HttpGet("range", Name = "GetDigitalAssetsByIds")]
        public async Task<ActionResult<GetDigitalAssetsByIdsResponse>> GetByIds([FromQuery] Guid[] digitalAssetIds)
        {
            var request = new GetDigitalAssetsByIdsRequest {  DigitalAssetIds = digitalAssetIds };

            return await _mediator.Send(request);
        }

        [HttpPost("upload", Name = "UploadDigitalAsset"), DisableRequestSizeLimit]
        public async Task<ActionResult<UploadDigitalAssetResponse>> Save()
            => await _mediator.Send(new UploadDigitalAssetRequest());

        [AllowAnonymous]
        [HttpGet("serve/{digitalAssetId}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Serve([FromRoute] Guid digitalAssetId)
        {
            var request = new GetDigitalAssetByIdRequest { DigitalAssetId = digitalAssetId };

            var response = await _mediator.Send(request);

            if (response.DigitalAsset == null)
                return new NotFoundObjectResult(null);

            return new FileContentResult(response.DigitalAsset.Bytes, response.DigitalAsset.ContentType);
        }


        [HttpDelete("{digitalAssetId}", Name = "RemoveDigitalAsset")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveDigitalAssetResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveDigitalAssetResponse>> Remove([FromRoute] Guid digitalAssetId)
        {
            var request = new RemoveDigitalAssetRequest { DigitalAssetId = digitalAssetId };

            return await _mediator.Send(request);
        }
    }
}
