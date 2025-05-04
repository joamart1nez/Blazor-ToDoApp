using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ToDoApp.Application.Features.Shared.Enums;

namespace ToDoApp.Infrastructure.Persistence.Entities;

/// <summary>
/// Represents a task item in the ToDo application.
/// </summary>
public class TaskItemEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the title of the task (required).
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Comment("The title of the task.")]
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the task (optional).
    /// </summary>
    [MaxLength(500)]
    [Comment("The detailed description of the task.")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets whether the task is completed.
    /// </summary>
    [Comment("Indicates if the task is completed.")]
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Gets or sets the optional due date for the task.
    /// </summary>
    [Comment("The optional due date for the task.")]
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Gets or sets the priority level of the task.
    /// Defaults to <see cref="Priority.Medium"/>.
    /// </summary>
    [Comment("The priority level of the task.")]
    public Priority Priority { get; set; } = Priority.Medium;

    // Navigation properties
    /// <summary>
    /// Gets or sets the category associated with the task (optional).
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category navigation property.
    /// </summary>
    [ForeignKey(nameof(CategoryId))]
    public virtual CategoryEntity? Category { get; set; }
}