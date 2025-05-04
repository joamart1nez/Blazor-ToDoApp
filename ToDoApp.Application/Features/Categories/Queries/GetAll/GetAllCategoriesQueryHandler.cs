using MediatR;

using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Categories.Repositories;

namespace ToDoApp.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoriesQueryHandler(ICategoriesRepository repository) : IRequestHandler<GetAllCategoriesQuery, List<Category>>
{
    public Task<List<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken) =>
        repository.GetAllAsync();
}
