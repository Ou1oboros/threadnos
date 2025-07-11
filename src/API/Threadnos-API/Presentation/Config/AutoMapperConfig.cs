using AutoMapper;
using Threadnos_API.Application.Mappings;

namespace Threadnos_API.Presentation.Config;

public static class AutoMapperConfig
{
    public static IServiceCollection AddAutoMapperProfile(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DefaultMapper>();
        });

        services.AddSingleton(config.CreateMapper());
        return services;
    }
}