using ToDoApp.Application.Features.Categories.Domain;

namespace ToDoApp.Application.Features.Categories.Repositories;

public interface ICategoriesRepository
{
    Task<List<Category>> GetAllAsync();

    Task CreateAsync(Category item);

    Task DeleteByIdAsync(int Id);

    Task<bool> CheckIfWasAssignedToATaskAsync(int Id);
}
