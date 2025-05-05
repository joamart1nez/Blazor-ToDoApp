using Microsoft.AspNetCore.Components;

using ToDoApp.Application.Features.Shared.Enums;
using ToDoApp.Application.Features.Tasks.Commands.Create;

namespace ToDoApp.Web.Pages.Tasks;

public partial class CreateTaskPage : BaseFormTaskPage
{
    protected override void OnInitialized()
    {
        TaskItem = new()
        {
            Title = string.Empty,
            Description = string.Empty,
            DueDate = null,
            Priority = Priority.Medium
        };
    }

    protected override async Task SubmitAsync()
    {
        IsSubmitting = true;
        try
        {
            CreateTaskCommand createTaskCommand = Mapper.Map<CreateTaskCommand>(TaskItem);
            createTaskCommand.CategoryId = CategoryId;

            await Mediator.Send(createTaskCommand);
            ShowSuccessMessage("Task created successfully");
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error creating task: {ex.Message}");
        }
        finally
        {
            IsSubmitting = false;
            NavigationManager.NavigateTo(TasksRoute.Index);
        }
    }
}