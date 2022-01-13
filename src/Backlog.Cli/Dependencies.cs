using Backlog.Api.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Backlog.Cli
{
    public static class Dependencies
    {
        public static void Configure(IServiceCollection services)
        {

            // TODO: Implement without default
            Backlog.Api.Dependencies.Configure(services, default);

            //TODO: Implement without default
            Backlog.Api.Dependencies.ConfigureAuth(services, default, default);

            services.AddMediatR(typeof(IBacklogDbContext), typeof(Program));
        }
    }
}
