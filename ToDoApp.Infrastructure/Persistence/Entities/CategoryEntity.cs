using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Infrastructure.Persistence.Entities;

/// <summary>
/// Represents a category for grouping tasks.
/// </summary>
public class CategoryEntity : EntityBase
{
    /// <summary>
    /// Gets or sets the name of the category (required).
    /// </summary>
    [Required]
    [MaxLength(50)]
    [Comment("The name of the category.")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the color code (e.g., hex) for UI display.
    /// </summary>
    [MaxLength(7)] // #RRGGBB
    [Comment("The color code for the category (e.g., #FF5733).")]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the collection of tasks associated with this category.
    /// </summary>
    public virtual ICollection<TaskItemEntity> Tasks { get; set; } = [];
}