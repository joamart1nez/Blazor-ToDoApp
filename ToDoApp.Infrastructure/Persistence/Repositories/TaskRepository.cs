using AutoMapper;

using Microsoft.EntityFrameworkCore;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;
using ToDoApp.Infrastructure.Persistence.Entities;

namespace ToDoApp.Infrastructure.Persistence.Repositories;

public class TaskRepository(AppDbContext dbContext, IMapper mapper) : ITaskRepository
{
    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        TaskItemEntity? taskItemEntity = await dbContext.TaskItems
            .AsNoTracking()
            .Where(task => task.Id == id)
            .Include(task => task.Category)
            .FirstOrDefaultAsync();

        return taskItemEntity is not null ? mapper.Map<TaskItem>(taskItemEntity) : null;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        List<TaskItemEntity> taskItems = await dbContext.TaskItems
            .Include(task => task.Category)
            .AsNoTracking().ToListAsync();
        return mapper.Map<List<TaskItem>>(taskItems);
    }

    public async Task CreateAsync(TaskItem item)
    {
        TaskItemEntity taskItemEntity = mapper.Map<TaskItemEntity>(item);
        await dbContext.TaskItems.AddAsync(taskItemEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task EditAsync(TaskItem item)
    {
        TaskItemEntity existingEntity = await dbContext.TaskItems
            .Where(t => t.Id == item.Id)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Task with id {item.Id} not found");

        mapper.Map(item, existingEntity);

        existingEntity.UpdatedAt = DateTime.UtcNow;
        dbContext.Entry(existingEntity).State = EntityState.Modified;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskItem item)
    {
        TaskItemEntity taskItemEntity = mapper.Map<TaskItemEntity>(item);
        dbContext.Remove(taskItemEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int Id)
    {
        TaskItemEntity? taskItemEntity = await dbContext.TaskItems
            .Where(task => task.Id == Id)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Task with id {Id} not found");

        dbContext.Remove(taskItemEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task ToggleStatusById(int Id)
    {
        TaskItemEntity taskEntity = await dbContext.TaskItems.FirstOrDefaultAsync(task => task.Id == Id)
            ?? throw new KeyNotFoundException($"Task with id {Id} not found");

        taskEntity.IsCompleted = !taskEntity.IsCompleted;
        await dbContext.SaveChangesAsync();
    }

    public async Task<TaskStatistics> GetTaskStatisticsAsync() => new()
    {
        CompletedCount = await dbContext.TaskItems.CountAsync(t => t.IsCompleted),
        IncompleteCount = await dbContext.TaskItems.CountAsync(t => !t.IsCompleted),
        CountByPriority = await dbContext.TaskItems.GroupBy(t => t.Priority).ToDictionaryAsync(g => g.Key, g => g.Count())
    };
}
