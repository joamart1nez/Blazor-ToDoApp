namespace ToDoApp.Application.Features.Categories.Domain;

/// <summary>
/// Represents a category for organizing tasks.
/// </summary>
public class Category
{
    /// <summary>
    /// Unique identifier for the category.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Date when the category was created (UTC).
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date when the category was last updated (UTC).
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Name of the category (required).
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Color code (e.g., hex) for UI display.
    /// </summary>
    public string? Color { get; set; }

    public static Category Create(string? name = null, string? color = null) => new() { Name = name ?? string.Empty, Color = color };
}
