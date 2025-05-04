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

    protected string ChartHeight = "600px";

    protected override async Task OnInitializedAsync()
    {
        TaskStatistics TaskStatistics = await Mediator.Send(new TaskStatisticsQuery());

        CompletitionLabels = ["Complete", "Incomplete"];
        CompletitionData = [(double)TaskStatistics.CompletedCount, (double)TaskStatistics.IncompleteCount];

        PriorityLabels = TaskStatistics.CountByPriority.Select(p => p.Key.ToString()).ToArray();
        PriorityData = TaskStatistics.CountByPriority.Select(p => (double)p.Value).ToArray();
    }
}
