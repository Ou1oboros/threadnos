using Microsoft.EntityFrameworkCore;
using Threadnos_API.Application.Services.Abstraction;
using Threadnos_API.Application.Services.Implementation;
using Threadnos_API.Domain.IRepositories;
using Threadnos_API.Domain.Services.Abstraction;
using Threadnos_API.Domain.Services.Implementation;
using Threadnos_API.Infrastructure.Persistence;
using Threadnos_API.Infrastructure.Persistence.Repositories;
using Threadnos_API.Shared.Common;

namespace Threadnos_API.Presentation.Config;

public static class ServicesConfig
{
    public static IServiceCollection AddProjectServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<RequestContext>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
                .UseSnakeCaseNamingConvention());
        services.AddHttpContextAccessor();
        services.AddScoped<IThreadlineService, ThreadlineService>();
        services.AddScoped<IThreadlineRepository, ThreadlineRepository>();
        services.AddScoped<IThreadlineDomainService, ThreadlineDomainService>();

        return services;
    }
}