using MediatR;

using System.ComponentModel.DataAnnotations;

using ToDoApp.Application.Features.Tasks.Domain;

namespace ToDoApp.Application.Features.Tasks.Queries.Get;

public class GetTaskQuery : IRequest<TaskItem>
{
    [Required]
    public required int Id { get; set; }
}
