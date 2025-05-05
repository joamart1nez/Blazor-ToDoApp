using System.ComponentModel.DataAnnotations;

using ToDoApp.Application.Features.Shared.Enums;

namespace ToDoApp.Application.Features.Tasks.Commands.Shared;

public abstract class BaseTaskCommand
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }

    [Required]
    public Priority Priority { get; set; } = Priority.Medium;

    public int? CategoryId { get; set; }
}