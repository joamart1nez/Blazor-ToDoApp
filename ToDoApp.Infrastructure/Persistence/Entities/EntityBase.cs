using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Infrastructure.Persistence.Entities;

/// <summary>
/// Represents the base class for all entities in the domain.
/// Provides common properties such as unique identifier and audit timestamps.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the UTC date and time when the entity was created.
    /// </summary>
    [Required]
    [Comment("The UTC timestamp when the entity was created.")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the UTC date and time when the entity was last updated.
    /// </summary>
    [Required]
    [Comment("The UTC timestamp when the entity was last updated.")]
    public DateTime? UpdatedAt { get; set; }
}
