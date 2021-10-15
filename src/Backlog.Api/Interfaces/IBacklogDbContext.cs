using Backlog.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace Backlog.Api.Interfaces
{
    public interface IBacklogDbContext
    {
        DbSet<Story> Stories { get; }
        DbSet<StoredEvent> StoredEvents { get; }
        DbSet<Bug> Bugs { get; }
        DbSet<StoryStatus> StoryStatuses { get; }
        DbSet<Profile> Profiles { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
