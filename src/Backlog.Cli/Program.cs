using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Backlog.Cli;

class Program
{
    static void Main(string[] args)
    {
        var mediator = BuildContainer().Services.GetService<IMediator>();

        ProcessArgs(mediator, args);
    }

    public static IHost BuildContainer()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices(x =>
            {
                Dependencies.Configure(x);
            
            }).Build();
    }

    public static void ProcessArgs(IMediator mediator, string[] args)
    {
        try
        {
            if (args.Length == 0 || args[0].StartsWith("-"))
            {
                args = new string[1] { "default" }.Concat(args).ToArray();
            }

            var verbs = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type => type.GetCustomAttributes(typeof(VerbAttribute), true).Length > 0)
                .ToArray();

            Parser.Default.ParseArguments(args, verbs)
                .WithParsed(
                  (dynamic request) => mediator.Send(request));
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
