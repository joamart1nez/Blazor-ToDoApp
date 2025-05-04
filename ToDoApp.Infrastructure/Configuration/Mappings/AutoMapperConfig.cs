using AutoMapper;

namespace ToDoApp.Infrastructure.Configuration.Mappings;

public class AutoMapperConfig : Profile
{
    /// <summary>
    /// Registers the profiles for the application mappings.
    /// </summary>
    /// <param name="cfg"></param>
    public static void RegisterProfiles(IMapperConfigurationExpression cfg)
    {
        cfg.AddProfile<TaskMappingProfile>();
        cfg.AddProfile<CategoryMappingProfile>();
    }
}
