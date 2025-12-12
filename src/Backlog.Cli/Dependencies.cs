using Backlog.Core;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Backlog.Cli;
public static class Dependencies
{
    private static IConfiguration Configuration;
    public static void Configure(IServiceCollection services)
    {
        var configuration = Create();

        var webHostEnvironement = new WebHostEnvironment();

        // TODO: Implement without default
        Backlog.Api.Dependencies.Configure(services, configuration);

        //TODO: Implement without default
        Backlog.Api.Dependencies.ConfigureAuth(services, configuration, webHostEnvironement);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IBacklogDbContext>());
    }

    public static IConfiguration Create()
    {
        if (Configuration == null)
        {
            var basePath = Path.GetFullPath("../../../../../src/Backlog.Api");

            Configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", false)
                .Build();
        }

        return Configuration;
    }
}

public class WebHostEnvironment : IWebHostEnvironment
{
    public WebHostEnvironment()
    {
        EnvironmentName = "Development";
    }
    public string WebRootPath { get; set; }
    public IFileProvider WebRootFileProvider { get; set; }
    public string ApplicationName { get; set; }
    public IFileProvider ContentRootFileProvider { get; set; }
    public string ContentRootPath { get; set; }
    public string EnvironmentName { get; set; }
}