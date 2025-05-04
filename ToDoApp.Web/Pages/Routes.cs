namespace ToDoApp.Web.Pages;

public static class HomeRoute
{
    private const string BasePath = "/";

    public const string Index = BasePath;
}

public static class TasksRoute
{
    private const string BasePath = "/tasks";

    private const string IdPlaceholder = "{id:int}";

    public const string Index = BasePath;

    public const string Create = $"{BasePath}/create";

    public const string EditTemplate = $"{BasePath}/edit/{IdPlaceholder}";

    public const string DeleteTemplate = $"{BasePath}/delete/{IdPlaceholder}";

    public static string Edit(int id) => $"{BasePath}/edit/{id}";

    public static string Delete(int id) => $"{BasePath}/delete/{id}";

    public static string GetById(string routeTemplate, int id)
    {
        return routeTemplate.Replace(IdPlaceholder, id.ToString());
    }
}

public static class CategoriesRoute
{
    private const string BasePath = "/categories";

    public const string Index = BasePath;

    public const string Create = $"{BasePath}/create";
}
