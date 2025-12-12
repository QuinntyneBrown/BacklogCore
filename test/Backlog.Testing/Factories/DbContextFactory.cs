using Backlog.Api.Data;
using Backlog.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using System.Threading.Tasks;

namespace Backlog.Testing;

public static class DbContextFactory
{
    private static Respawner _respawner;

    public static async Task<IBacklogDbContext> Create(string nameOfConnectionString = "ConnectionStrings:TestConnection")
    {
        var configuration = ConfigurationFactory.Create();

        _respawner = await Respawner.CreateAsync(configuration[nameOfConnectionString], new RespawnerOptions
        {
            DbAdapter = DbAdapter.SqlServer,
            SchemasToInclude = new[] { "dbo" }
        });

        var container = new ServiceCollection()
            .AddDbContext<BacklogDbContext>(options =>
            {
                options.UseSqlServer(configuration[nameOfConnectionString]);
            })
            .BuildServiceProvider();

        var context = container.GetService<BacklogDbContext>();

        await context.Database.EnsureDeletedAsync();

        await context.Database.MigrateAsync();

        await context.Database.EnsureCreatedAsync();

        var connection = context.Database.GetDbConnection();

        await _respawner.ResetAsync(configuration[nameOfConnectionString]);

        SeedData.Seed(context);

        return context;
    }
}