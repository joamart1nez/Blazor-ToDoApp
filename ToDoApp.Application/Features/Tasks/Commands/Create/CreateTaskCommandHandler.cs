using AutoMapper;

using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Commands.Create;

public class CreateTaskCommandHandler(ITaskRepository taskRepository, IMapper mapper) : IRequestHandler<CreateTaskCommand>
{
    public async Task Handle(CreateTaskCommand command, CancellationToken cancellationToken)
    {
        try
        {
            TaskItem taskItem = mapper.Map<TaskItem>(command);
            await taskRepository.CreateAsync(taskItem);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
