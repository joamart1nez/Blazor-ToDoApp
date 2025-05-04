using AutoMapper;

using MediatR;

using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Categories.Repositories;

namespace ToDoApp.Application.Features.Categories.Commands.Create;

public class CreateCategoryCommandHandler(ICategoriesRepository repository, IMapper mapper) : IRequestHandler<CreateCategoryCommand>
{
    public async Task Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            Category category = mapper.Map<Category>(command);
            await repository.CreateAsync(category);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
