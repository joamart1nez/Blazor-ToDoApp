using ToDoApp.Application.Features.Shared.Enums;

namespace ToDoApp.Application.Features.Tasks.Domain;

public class TaskStatistics
{
    public int CompletedCount { get; set; }

    public int IncompleteCount { get; set; }

    public Dictionary<Priority, int> CountByPriority { get; set; } = [];

    public Dictionary<string, int> CountByCategory { get; set; } = [];

    public int TotalCount => CompletedCount + IncompleteCount;
}

