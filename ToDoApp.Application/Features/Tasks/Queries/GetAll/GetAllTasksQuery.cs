using MediatR;

using ToDoApp.Application.Features.Tasks.Domain;

namespace ToDoApp.Application.Features.Tasks.Queries.GetAll;

public class GetAllTasksQuery : IRequest<List<TaskItem>>
{
}
