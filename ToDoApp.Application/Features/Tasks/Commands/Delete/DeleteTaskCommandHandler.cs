using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Commands.Delete;

public class DeleteTaskCommandHandler(ITaskRepository repository) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        try
        {
            TaskItem? taskItem = await repository.GetByIdAsync(command.Id)
                ?? throw new Exception($"Task with Id '{command.Id}' not found.");

            await repository.DeleteAsync(taskItem!);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
