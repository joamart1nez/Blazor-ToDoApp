using AutoMapper;

using ToDoApp.Application.Features.Categories.Commands.Create;
using ToDoApp.Application.Features.Categories.Domain;
using ToDoApp.Infrastructure.Persistence.Entities;

namespace ToDoApp.Infrastructure.Configuration.Mappings;

public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryEntity>();
        CreateMap<CategoryEntity, Category>();

        CreateMap<CreateCategoryCommand, Category>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Category, CreateCategoryCommand>();
    }
}
