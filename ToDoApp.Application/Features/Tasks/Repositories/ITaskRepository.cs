using ToDoApp.Application.Features.Tasks.Domain;

namespace ToDoApp.Application.Features.Tasks.Repositories;

/// <summary>
/// Defines the contract for a repository that manages <see cref="TaskItem"/> entities.
/// Provides asynchronous operations for task data access.
/// </summary>
public interface ITaskRepository
{
    Task<TaskItem?> GetByIdAsync(int Id);

    Task<List<TaskItem>> GetAllAsync();

    Task CreateAsync(TaskItem item);

    Task EditAsync(TaskItem item);

    Task DeleteAsync(TaskItem item);

    Task ToggleStatusById(int Id);

    Task<TaskStatistics> GetTaskStatisticsAsync();
}