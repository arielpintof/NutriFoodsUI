using AutoMapper;
using NutriFoods_UI.Data.Dto.Insertion;

namespace NutriFoods_UI.Data.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RecipeDto, MinimalMenuRecipe>()
            .ForMember(d => d.RecipeId,
                o => o.MapFrom(src => src.Id))
            .ForMember(d => d.Portions,
                o => o.MapFrom(src => src.Portions));

        CreateMap<DailyMenuDto, MinimalDailyMenu>()
            .ForMember(d => d.IntakePercentage,
                o => o.MapFrom(src => src.IntakePercentage))
            .ForMember(d => d.MealType,
                o => o.MapFrom(src => src.MealType))
            .ForMember(d => d.Nutrients,
                o => o.MapFrom(src => src.Nutrients))
            .ForMember(d => d.Targets,
                o => o.MapFrom(src => src.Targets))
            .ForMember(d => d.Recipes,
                o => o.MapFrom(src => src.Recipes));

        CreateMap<DailyPlanDto, MinimalDailyPlan>()
            .ForMember(d => d.Days,
                o => o.MapFrom(src => src.Days))
            .ForMember(d => d.PhysicalActivityLevel,
                o => o.MapFrom(src => src.PhysicalActivityLevel))
            .ForMember(d => d.PhysicalActivityFactor,
                o => o.MapFrom(src => src.PhysicalActivityFactor))
            .ForMember(d => d.Nutrients,
                o => o.MapFrom(src => src.Nutrients))
            .ForMember(d => d.Targets,
                o => o.MapFrom(src => src.Targets))
            .ForMember(d => d.Menus,
                o => o.MapFrom(src => src.Menus));
    }
    
    
}