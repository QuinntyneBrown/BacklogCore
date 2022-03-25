using Backlog.SharedKernel;
using FluentValidation;
using MediatR;

namespace Backlog.Core
{
    public class CreateDigitalAssetValidator : AbstractValidator<CreateDigitalAssetRequest>
    {
        public CreateDigitalAssetValidator()
        {
            RuleFor(request => request.DigitalAsset).NotNull();
            RuleFor(request => request.DigitalAsset).SetValidator(new DigitalAssetValidator());
        }
    }

    public class CreateDigitalAssetRequest : IRequest<CreateDigitalAssetResponse>
    {
        public DigitalAssetDto? DigitalAsset { get; set; }
    }

    public class CreateDigitalAssetResponse : ResponseBase
    {
        public DigitalAssetDto? DigitalAsset { get; set; }
    }

    public class CreateDigitalAssetHandler : IRequestHandler<CreateDigitalAssetRequest, CreateDigitalAssetResponse>
    {
        private readonly IBacklogDbContext _context;

        public CreateDigitalAssetHandler(IBacklogDbContext context)
            => _context = context;
        public async Task<CreateDigitalAssetResponse> Handle(CreateDigitalAssetRequest request, CancellationToken cancellationToken)
        {
            var digitalAsset = new DigitalAsset();

            _context.DigitalAssets.Add(digitalAsset);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                DigitalAsset = digitalAsset.ToDto()
            };
        }

    }

}
