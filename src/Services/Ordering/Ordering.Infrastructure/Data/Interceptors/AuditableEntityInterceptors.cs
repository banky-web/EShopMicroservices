using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;


namespace Ordering.Infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptors : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        public void UpdateEntities(DbContext? context)
        {
            if (context == null) return;
            var entries = context.ChangeTracker.Entries<IEntity>();
            var now = DateTime.UtcNow;
            var user = "mehmet";
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = user;
                    entry.Entity.CreatedAt = now;
                }
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified
                    || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = user;
                    entry.Entity.LastModified = now;

                }
            }
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
    entry.References.Any(r =>
        r.TargetEntry != null &&
        r.TargetEntry.Metadata.IsOwned() &&
        (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));


}
