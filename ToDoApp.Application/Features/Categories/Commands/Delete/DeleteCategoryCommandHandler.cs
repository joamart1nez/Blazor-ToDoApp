using MediatR;

using ToDoApp.Application.Features.Categories.Repositories;

namespace ToDoApp.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(ICategoriesRepository repository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            await repository.DeleteByIdAsync(command.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
