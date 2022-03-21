using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Backlog.Core;
using Backlog.Api.Core;
using Backlog.Api.Interfaces;

namespace Backlog.Core
{
    public class CreateUser
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.User).NotNull();
                RuleFor(request => request.User).SetValidator(new UserValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public UserDto User { get; set; }
        }

        public class Response: ResponseBase
        {
            public UserDto User { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IBacklogDbContext _context;
            private readonly IPasswordHasher _passwordHasher;

            public Handler(IBacklogDbContext context, IPasswordHasher passwordHasher)
            {
                _context = context;
                _passwordHasher = passwordHasher;
            }
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var @event = new DomainEvents.CreateUser(request.User.Username, request.User.Password, _passwordHasher);

                var user = new User(@event);
                
                _context.Users.Add(user);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    User = user.ToDto()
                };
            }
            
        }
    }
}
