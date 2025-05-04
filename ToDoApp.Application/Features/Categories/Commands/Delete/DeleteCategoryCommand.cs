using MediatR;

using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommand : IRequest
{
    [Required]
    public int Id { get; set; }
}
