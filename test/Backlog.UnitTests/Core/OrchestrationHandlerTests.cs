using Backlog.Api.Core;
using Backlog.Api.Interfaces;
using Backlog.Testing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Backlog.UnitTests.Core
{
    public class OrchestrationHandlerTests: TestBase
    {
        [Fact]
        public async Task HandleTests()
        {
            var container = _serviceCollection
                .AddMediatR(typeof(OrchestrationHandlerTests))
                .AddSingleton<IOrchestrationHandler, OrchestrationHandler>()
                .BuildServiceProvider();

            var sut = container.GetService<IOrchestrationHandler>();

            var startWith = new Create();

            var result1 = await sut.Handle<bool>(startWith, (ctx) => @event =>
            {
                switch(@event)
                {
                    case Created created:
                        ctx.SetResult(true);
                        break;
                }
            });

            var result2 = await sut.Handle<bool>(startWith, (ctx) => @event =>
            {
                switch (@event)
                {
                    case Created created:
                        ctx.SetResult(true);
                        break;
                }
            });

            Assert.True(result1);
        }

        public class Create : BaseDomainEvent { }

        public class Created : BaseDomainEvent { }

        public class Handler : INotificationHandler<Create>
        {
            private readonly IOrchestrationHandler _orchestrationHandler;
            public Handler(IOrchestrationHandler orchestrationHandler)
            {
                _orchestrationHandler = orchestrationHandler;
            }
            public async Task Handle(Create notification, CancellationToken cancellationToken)
            {
                await _orchestrationHandler.Publish(new Created());
            }
        }
    }
}
