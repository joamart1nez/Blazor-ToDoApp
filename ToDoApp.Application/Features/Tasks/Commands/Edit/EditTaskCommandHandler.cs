using AutoMapper;

using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Commands.Edit;

public class EditTaskCommandHandler(ITaskRepository repository, IMapper mapper) : IRequestHandler<EditTaskCommand>
{
    public async Task Handle(EditTaskCommand command, CancellationToken cancellationToken)
    {
        TaskItem taskItem = mapper.Map<TaskItem>(command);
        await repository.EditAsync(taskItem);
    }
}
