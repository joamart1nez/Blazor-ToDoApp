using MediatR;

using ToDoApp.Application.Features.Tasks.Commands.Shared;

namespace ToDoApp.Application.Features.Tasks.Commands.Create;

public class CreateTaskCommand : BaseTaskCommand, IRequest
{
}
