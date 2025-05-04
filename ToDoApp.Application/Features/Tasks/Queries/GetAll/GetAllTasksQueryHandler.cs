using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Queries.GetAll;

public class GetAllTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
{
    public Task<List<TaskItem>> Handle(GetAllTasksQuery query, CancellationToken cancellationToken) => taskRepository.GetAllAsync();
}
