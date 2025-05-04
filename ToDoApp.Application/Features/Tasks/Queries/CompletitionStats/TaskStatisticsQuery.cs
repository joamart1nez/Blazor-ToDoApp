using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;

namespace ToDoApp.Application.Features.Tasks.Queries.CompletitionStats;

public class TaskStatisticsQuery : IRequest<TaskStatistics>
{
}
