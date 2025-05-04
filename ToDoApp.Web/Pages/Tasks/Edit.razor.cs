using Microsoft.AspNetCore.Components;

using ToDoApp.Application.Features.Tasks.Commands.Edit;
using ToDoApp.Application.Features.Tasks.Queries.Get;

namespace ToDoApp.Web.Pages.Tasks;

public partial class EditTaskPage : BaseFormTaskPage
{
    [Parameter] public int Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        IsLoading = true;
        try
        {
            GetTaskQuery getTaskQuery = new() { Id = Id };
            TaskItem = await Mediator.Send(getTaskQuery);
        }
        catch (Exception ex)
        {
            ShowErrorMessage(ex.Message ?? "Error loading task");
        }
        finally
        {
            IsLoading = false;
        }
    }

    protected override async Task SubmitAsync()
    {
        if (TaskItem is null) return;

        IsSubmitting = true;
        try
        {
            EditTaskCommand editTaskCommand = Mapper.Map<EditTaskCommand>(TaskItem);
            await Mediator.Send(editTaskCommand);
            ShowSuccessMessage("Task edited successfully");
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error editing task: {ex.Message}");
        }
        finally
        {
            IsSubmitting = false;
            NavigationManager.NavigateTo(TasksRoute.Index);
        }
    }
}