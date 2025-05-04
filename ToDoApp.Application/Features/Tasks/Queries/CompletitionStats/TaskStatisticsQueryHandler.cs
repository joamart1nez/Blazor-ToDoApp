using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Queries.CompletitionStats;

public class TaskStatisticsQueryHandler(ITaskRepository taskRepository) : IRequestHandler<TaskStatisticsQuery, TaskStatistics>
{
    public Task<TaskStatistics> Handle(TaskStatisticsQuery request, CancellationToken cancellationToken) =>
        taskRepository.GetTaskStatisticsAsync();
}
