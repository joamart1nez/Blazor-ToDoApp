using MediatR;

using System.ComponentModel.DataAnnotations;

using ToDoApp.Application.Features.Tasks.Commands.Shared;

namespace ToDoApp.Application.Features.Tasks.Commands.Edit;

public class EditTaskCommand : BaseTaskCommand, IRequest
{
    [Required]
    public int Id { get; set; }
}
