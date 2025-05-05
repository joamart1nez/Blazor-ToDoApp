using MediatR;

using Microsoft.AspNetCore.Components;

using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Application.Features.Tasks.Queries.CompletitionStats;

namespace ToDoApp.Web.Pages.Home;

public partial class HomePage : ComponentBase
{
    [Inject] IMediator Mediator { get; set; } = null!;

    protected double[] CompletitionData = [];

    protected string[] CompletitionLabels = [];

    protected double[] PriorityData = [];

    protected string[] PriorityLabels = [];

    protected double[] CategoryData = [];

    protected string[] CategoryLabels = [];

    protected string ChartHeight = "400px";

    protected override async Task OnInitializedAsync()
    {
        TaskStatistics taskStatistics = await Mediator.Send(new TaskStatisticsQuery());

        CompletitionLabels = ["Complete", "Incomplete"];
        CompletitionData = [(double)taskStatistics.CompletedCount, (double)taskStatistics.IncompleteCount];

        PriorityLabels = taskStatistics.CountByPriority.Select(p => p.Key.ToString()).ToArray();
        PriorityData = taskStatistics.CountByPriority.Select(p => (double)p.Value).ToArray();

        CategoryLabels = taskStatistics.CountByCategory.Select(c => c.Key).ToArray();
        CategoryData = taskStatistics.CountByCategory.Select(c => (double)c.Value).ToArray();
    }
}
