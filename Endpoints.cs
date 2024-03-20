using AutoMapper;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService;

public static class Endpoints
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapGet("/platforms", async
            (IPlatformRepository repository, IMapper mapper)
            => mapper.Map<List<PlatformReadDto>>(await repository.GetAllPlatforms()));

        
        app.MapGet("/platforms/{id:int}", async
            (int id, IPlatformRepository repository, IMapper mapper) =>
            await repository.GetPlatformById(id) is { } platform
                ? Results.Ok(mapper.Map<PlatformReadDto>(platform))
                : Results.NotFound());


        app.MapPost("/platforms", async
            (PlatformCreateDto command, IPlatformRepository repository, IMapper mapper) =>
        {
            
            var platform = mapper.Map<Platform>(command);
            await repository.CreatePlatform(platform);
            await repository.SaveChanges();

            return Results.Created($"/platforms/{platform.Id}", mapper.Map<PlatformReadDto>(platform));
        });

        return app;
    }
}