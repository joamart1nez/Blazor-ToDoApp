using MediatR;

using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Commands.Delete;

public class DeleteTaskCommandHandler(ITaskRepository repository) : IRequestHandler<DeleteTaskCommand>
{
    public async Task Handle(DeleteTaskCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await repository.DeleteByIdAsync(command.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
