using AutoMapper;

using Microsoft.EntityFrameworkCore;

using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Categories.Repositories;
using ToDoApp.Infrastructure.Persistence.Entities;

namespace ToDoApp.Infrastructure.Persistence.Repositories;

public class CategoriesRepository(AppDbContext dbContext, IMapper mapper) : ICategoriesRepository
{
    public async Task CreateAsync(Category item)
    {
        CategoryEntity categoryEntity = mapper.Map<CategoryEntity>(item);
        await dbContext.Categories.AddAsync(categoryEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int Id)
    {
        CategoryEntity? categoryEntity = await dbContext.Categories
            .Where(task => task.Id == Id)
            .FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Category with id {Id} not found");

        dbContext.Remove(categoryEntity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Category>> GetAllAsync()
    {
        List<CategoryEntity> taskItems = await dbContext.Categories.AsNoTracking().ToListAsync();
        return mapper.Map<List<Category>>(taskItems);
    }

    public Task<Category?> GetByIdAsync(int Id)
    {
        throw new NotImplementedException();
    }
}
