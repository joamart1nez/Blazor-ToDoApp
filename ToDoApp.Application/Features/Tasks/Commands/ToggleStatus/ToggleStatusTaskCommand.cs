using MediatR;

using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Features.Tasks.Commands.ToggleStatus;

public class ToggleStatusTaskCommand : IRequest
{
    [Required]
    public required int Id { get; set; }
}
