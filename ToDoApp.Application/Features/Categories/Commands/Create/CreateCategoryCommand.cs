using MediatR;

namespace ToDoApp.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest
{
    public required string Name { get; set; }

    public string? Color { get; set; }
}
