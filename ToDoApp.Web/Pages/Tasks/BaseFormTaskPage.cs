using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using ToDoApp.Application.Features.Tasks.Domain;

namespace ToDoApp.Web.Pages.Tasks;

public abstract class BaseFormTaskPage : ComponentBase
{
    [Inject] protected IMediator Mediator { get; set; } = null!;
    [Inject] protected IMapper Mapper { get; set; } = null!;
    [Inject] protected NavigationManager NavigationManager { get; set; } = null!;
    [Inject] protected ISnackbar Snackbar { get; set; } = null!;

    protected TaskItem TaskItem { get; set; } = null!;
    protected int? CategoryId { get; set; } = null;
    protected bool IsSubmitting { get; set; } = false;
    protected bool IsLoading { get; set; } = false;

    protected abstract Task SubmitAsync();

    protected void UpdateCategoryId(int? newCategoryId)
    {
        CategoryId = newCategoryId;
    }

    protected void Cancel() => NavigationManager.NavigateTo(TasksRoute.Index);

    protected void ShowSuccessMessage(string message) => Snackbar.Add(message, Severity.Success);

    protected void ShowErrorMessage(string message) => Snackbar.Add(message, Severity.Error);
}