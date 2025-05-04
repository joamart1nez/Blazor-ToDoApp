using MediatR;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using ToDoApp.Application.Features.Tasks.Commands.Delete;
using ToDoApp.Application.Features.Tasks.Commands.ToggleStatus;
using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Queries.GetAll;

namespace ToDoApp.Web.Pages.Tasks;

public partial class TasksPage : ComponentBase
{
    [Inject]
    private IMediator Mediator { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    protected List<TaskItem> Tasks { get; private set; } = [];
    protected bool IsLoading { get; private set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await LoadTasks();
    }

    private async Task LoadTasks()
    {
        try
        {
            IsLoading = true;
            Tasks = await Mediator.Send(new GetAllTasksQuery());
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error loading tasks: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }

    protected async Task HandleDelete(int taskId)
    {
        try
        {
            IsLoading = true;

            await Mediator.Send(new DeleteTaskCommand { Id = taskId });
            await LoadTasks();
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error deleting task: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }

    protected async Task HandleToggleStatus(int taskId)
    {
        try
        {
            IsLoading = true;

            await Mediator.Send(new ToggleStatusTaskCommand { Id = taskId });
            await LoadTasks();
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error changing status task: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }
}