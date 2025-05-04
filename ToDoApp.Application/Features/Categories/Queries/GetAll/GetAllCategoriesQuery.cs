using MediatR;

using ToDoApp.Application.Features.Categories.Domain;

namespace ToDoApp.Application.Features.Categories.Queries.GetAll;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
}
