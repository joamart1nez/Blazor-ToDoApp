using System.ComponentModel.DataAnnotations;

using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Shared.Enums;

namespace ToDoApp.Application.Features.Tasks.Domain;

/// <summary>
/// Represents a task in the system.
/// </summary>
public class TaskItem
{
    /// <summary>
    /// Unique identifier for the task.
    /// </summary>
    public int Id { get; set; } = default;

    /// <summary>
    /// Date when the task was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Date when the task was last updated (UTC).
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Title of the task (required).
    /// </summary>
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title must be less than 100 characters")]
    public required string Title { get; set; }

    /// <summary>
    /// Detailed description of the task.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
    public string? Description { get; set; }

    /// <summary>
    /// Indicates if the task is completed.
    /// </summary>
    public bool IsCompleted { get; set; } = false;

    /// <summary>
    /// Optional due date for the task.
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Priority level of the task (default: Medium).
    /// </summary>
    public Priority Priority { get; set; }

    /// <summary>
    /// Associated category (optional).
    /// </summary>
    public Category? Category { get; set; }

    public bool Exist => Id is not 0;
}