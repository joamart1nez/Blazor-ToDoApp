using AutoMapper;

using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Application.Features.Tasks.Commands.Create;
using ToDoApp.Application.Features.Tasks.Commands.Edit;
using ToDoApp.Application.Features.Tasks.Domain;
using ToDoApp.Infrastructure.Persistence.Entities;

namespace ToDoApp.Infrastructure.Configuration.Mappings;

public class TaskMappingProfile : Profile
{
    public TaskMappingProfile()
    {
        CreateMap<TaskItemEntity, TaskItem>();
        CreateMap<TaskItem, TaskItemEntity>()
            .ForMember(dest => dest.Category, opt => opt.Ignore());

        CreateMap<TaskItem, CreateTaskCommand>();
        CreateMap<CreateTaskCommand, TaskItem>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom((src, dest) => src.CategoryId.HasValue
                ? new Category { Id = src.CategoryId.Value, Name = string.Empty }
                : null)
            );

        CreateMap<TaskItem, EditTaskCommand>();
        CreateMap<EditTaskCommand, TaskItem>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom((src, dest) => src.CategoryId.HasValue
                ? new Category { Id = src.CategoryId.Value, Name = string.Empty }
                : null)
            );
    }
}
