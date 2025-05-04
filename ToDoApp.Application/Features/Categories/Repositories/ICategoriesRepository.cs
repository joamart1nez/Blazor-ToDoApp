using ToDoApp.Application.Features.Categories.Domain;

namespace ToDoApp.Application.Features.Categories.Repositories;

public interface ICategoriesRepository
{
    Task<Category?> GetByIdAsync(int Id);

    Task<List<Category>> GetAllAsync();

    Task CreateAsync(Category item);

    Task DeleteByIdAsync(int Id);
}
