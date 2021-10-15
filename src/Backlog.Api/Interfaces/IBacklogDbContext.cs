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
        DbSet<Profile> Profiles { get; }
        DbSet<Status> Statuses { get; }
        DbSet<TaskItem> TaskItems { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
