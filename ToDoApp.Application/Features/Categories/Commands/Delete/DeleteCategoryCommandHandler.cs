using MediatR;

using ToDoApp.Application.Features.Categories.Repositories;

namespace ToDoApp.Application.Features.Categories.Commands.Delete;

public class DeleteCategoryCommandHandler(ICategoriesRepository repository) : IRequestHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        try
        {
            bool wasAssignedToATask = await repository.CheckIfWasAssignedToATaskAsync(command.Id);

            if (wasAssignedToATask)
            {
                throw new Exception(@"Category was assigned to a task. 
                                    Please remove the category from the task before deleting it.
                                    You can do this by using the Edit Task command.");
            }

            await repository.DeleteByIdAsync(command.Id);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
