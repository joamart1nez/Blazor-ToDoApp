using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Queries.Get;

public class GetTaskQueryHandler(ITaskRepository repository) : IRequestHandler<GetTaskQuery, TaskItem>
{
    public async Task<TaskItem> Handle(GetTaskQuery query, CancellationToken cancellationToken) =>
        await repository.GetByIdAsync(query.Id) ?? throw new Exception($"Task with id '{query.Id}' not found");
}
