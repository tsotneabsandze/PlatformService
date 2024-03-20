using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Profiles;

namespace PlatformService.Infrastructure;

public static class ServiceConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseInMemoryDatabase("inMem");
        });

        builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
        builder.Services.AddAutoMapper(typeof(PlatformsProfile));

        return builder;
    }
}

