using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;

using Serilog;
using Serilog.Events;

using ToDoApp.Infrastructure.Configuration;
using ToDoApp.Infrastructure.Configuration.Mappings;
using ToDoApp.Infrastructure.Persistence;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();

builder.Services.AddAutoMapper((serviceProvider, cfg) => AutoMapperConfig.RegisterProfiles(cfg), typeof(Program));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .LogTo(Console.WriteLine, LogLevel.Information)
           .EnableSensitiveDataLogging()
           );

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ToDoApp.Application.AssemblyReference)));

builder.Services.ConfigureToDoAppRepositories();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();