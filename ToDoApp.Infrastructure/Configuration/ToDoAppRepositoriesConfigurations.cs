using Microsoft.Extensions.DependencyInjection;

using ToDoApp.Application.Features.Tasks.Repositories;
using ToDoApp.Infrastructure.Persistence.Repositories;

namespace ToDoApp.Infrastructure.Configuration;

public static class ToDoAppRepositoriesConfigurations
{
    public static IServiceCollection ConfigureToDoAppRepositories(this IServiceCollection services) => services.AddScoped<ITaskRepository, TaskRepository>();
}
