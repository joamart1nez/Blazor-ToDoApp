using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using ToDoApp.Infrastructure.Persistence.Entities;

namespace ToDoApp.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TaskItemEntity> TaskItems { get; set; }

    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Saves changes to the database and adds timestamps to entities before saving.
    /// </summary>
    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    /// <summary>
    /// Saves changes to the database and adds timestamps to entities before saving.
    /// </summary>
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    /// <summary>
    /// Asynchronously saves changes to the database and adds timestamps to entities before saving.
    /// </summary>
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously saves changes to the database and adds timestamps to entities before saving.
    /// </summary>
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        AddTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    /// <summary>
    /// Adds timestamps to entities that implement the <see cref="EntityBase"/> interface,
    /// setting the created and updated timestamps as appropriate.
    /// </summary>
    private void AddTimestamps()
    {
        IEnumerable<EntityEntry> entities = ChangeTracker.Entries()
            .Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

        foreach (EntityEntry? entity in entities)
        {
            DateTime now = DateTime.UtcNow; // Current datetime
            EntityBase asEntityBase = (EntityBase)entity.Entity;

            if (entity.State is EntityState.Added)
            {
                asEntityBase.CreatedAt = now;
            }

            asEntityBase.UpdatedAt = now;
        }
    }
}
