using MediatR;

using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Features.Tasks.Commands.Delete;

public class DeleteTaskCommand : IRequest
{
    [Required]
    public int Id { get; set; }
}
