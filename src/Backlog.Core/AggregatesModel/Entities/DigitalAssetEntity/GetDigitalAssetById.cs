using Backlog.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Core
{
    public class GetDigitalAssetByIdRequest : IRequest<GetDigitalAssetByIdResponse>
    {
        public Guid DigitalAssetId { get; set; }
    }

    public class GetDigitalAssetByIdResponse : ResponseBase
    {
        public DigitalAssetDto? DigitalAsset { get; set; }
    }

    public class GetDigitalAssetByIdHandler : IRequestHandler<GetDigitalAssetByIdRequest, GetDigitalAssetByIdResponse>
    {
        private readonly IBacklogDbContext _context;

        public GetDigitalAssetByIdHandler(IBacklogDbContext context)
            => _context = context;
        public async Task<GetDigitalAssetByIdResponse> Handle(GetDigitalAssetByIdRequest request, CancellationToken cancellationToken)
        {
            return new()
            {
                DigitalAsset = (await _context.DigitalAssets.SingleOrDefaultAsync(x => x.DigitalAssetId == request.DigitalAssetId, cancellationToken))?.ToDto()
            };
        }

    }

}
