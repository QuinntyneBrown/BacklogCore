using Backlog.Api.Data;
using Backlog.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Respawn;
using System.Threading.Tasks;

namespace Backlog.Testing
{
    public static class DbContextFactory
    {
        private static Checkpoint _checkpoint;

        public static async Task<IBacklogDbContext> Create(string nameOfConnectionString = "ConnectionStrings:TestConnection")
        {
            var configuration = ConfigurationFactory.Create();

            _checkpoint = new Checkpoint()
            {
                TablesToIgnore = new string[1] {
                "__EFMigrationsHistory"
                }
            };

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

            await _checkpoint.Reset(configuration[nameOfConnectionString]);

            SeedData.Seed(context);

            return context;
        }
    }
}