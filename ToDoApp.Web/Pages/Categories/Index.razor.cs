using AutoMapper;

using MediatR;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using ToDoApp.Application.Features.Categories.Commands.Create;
using ToDoApp.Application.Features.Categories.Commands.Delete;
using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Categories.Queries.GetAll;

namespace ToDoApp.Web.Pages.Categories;

public partial class CategoriesPage : ComponentBase
{
    [Inject]
    private IMediator Mediator { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    private IMapper Mapper { get; set; } = null!;

    protected List<Category> Categories { get; private set; } = [];

    protected bool IsLoading { get; private set; } = true;

    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        try
        {
            IsLoading = true;
            Categories = await Mediator.Send(new GetAllCategoriesQuery());
        }
        catch (Exception ex)
        {
            Snackbar.Add($"Error loading categories: {ex.Message}", Severity.Error);
        }
        finally
        {
            IsLoading = false;
        }
    }

    public async Task CreateCategory(Category newCategory)
    {
        try
        {
            ValidateNewCategory(newCategory);

            CreateCategoryCommand createCategoryCommand = Mapper.Map<CreateCategoryCommand>(newCategory);
            await Mediator.Send(createCategoryCommand);
            ShowSuccessMessage("Category created successfully");

            await LoadCategories();
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error creating category: {ex.Message}");
        }
    }

    public async Task DeleteCategory(int Id)
    {
        try
        {
            DeleteCategoryCommand deleteCategoryCommand = new() { Id = Id };
            await Mediator.Send(deleteCategoryCommand);

            await LoadCategories();
        }
        catch (Exception ex)
        {
            ShowErrorMessage($"Error deleting category: {ex.Message}");
        }
    }

    private static void ValidateNewCategory(Category newCategory)
    {
        if (string.IsNullOrWhiteSpace(newCategory.Name))
        {
            throw new ArgumentException("Name cannot be empty");
        }
    }

    protected void ShowSuccessMessage(string message) => Snackbar.Add(message, Severity.Success);

    protected void ShowErrorMessage(string message) => Snackbar.Add(message, Severity.Error);
}
