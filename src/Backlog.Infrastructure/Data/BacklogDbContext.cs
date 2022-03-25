using Backlog.Core;
using Backlog.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Backlog.Api.Data
{
    public class BacklogDbContext: DbContext, IBacklogDbContext
    {
        private readonly INotificationService _notificationService;

        public DbSet<Story> Stories { get; private set; }
        public DbSet<StoredEvent> StoredEvents { get; private set; }
        public DbSet<Bug> Bugs { get; private set; }
        public DbSet<Profile> Profiles { get; private set; }
        public DbSet<Status> Statuses { get; private set; }
        public DbSet<TaskItem> TaskItems { get; private set; }
        public DbSet<Technology> Technologies { get; private set; }
        public DbSet<CompetencyLevel> CompetencyLevels { get; private set; }
        public DbSet<DigitalAsset> DigitalAssets { get; private set; }
        public DbSet<Sprint> Sprints { get; private set; }
        public DbSet<User> Users { get; private set; }
        public BacklogDbContext(DbContextOptions options, INotificationService notificationService)
            : base(options)
        {
            SavingChanges += DbContext_SavingChanges;
            SavedChanges += DbContext_SavedChanges;
            _notificationService = notificationService;
        }

        private void DbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Where(
                    e => e.State == EntityState.Added ||
                    e.State == EntityState.Modified)
                .Select(e => e.Entity)
                .ToList();
            
            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    StoredEvents.Add(storedEvent);
                }
            }
        }

        private void DbContext_SavedChanges(object sender, SavedChangesEventArgs e)
        {
            var entries = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .ToList();

            foreach (var aggregate in entries)
            {
                foreach (var storedEvent in aggregate.StoredEvents)
                {
                    var @event = JsonConvert.DeserializeObject(storedEvent.Data, Type.GetType(storedEvent.DotNetType));

                    _notificationService.OnNext(@event);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BacklogDbContext).Assembly);
        }

        public override void Dispose()
        {
            SavingChanges -= DbContext_SavingChanges;

            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            SavingChanges -= DbContext_SavingChanges;

            return base.DisposeAsync();
        }

    }
}
