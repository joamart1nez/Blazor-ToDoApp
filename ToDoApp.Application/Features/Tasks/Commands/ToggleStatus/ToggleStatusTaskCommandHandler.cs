using MediatR;

using ToDoApp.Application.Features.Tasks.Repositories;

namespace ToDoApp.Application.Features.Tasks.Commands.ToggleStatus;

public class ToggleStatusTaskCommandHandler(ITaskRepository repository) : IRequestHandler<ToggleStatusTaskCommand>
{
    public Task Handle(ToggleStatusTaskCommand request, CancellationToken cancellationToken) =>
        repository.ToggleStatusById(request.Id);
}
