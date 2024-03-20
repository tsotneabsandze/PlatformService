using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrePopulation(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
    }

    private static void SeedData(AppDbContext? ctx)
    {
        if (ctx != null && !ctx.Platforms.Any())
        {
            Console.WriteLine("seeding ...");

            ctx.Platforms.AddRange(
                new Platform { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                new Platform { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
            );

            ctx.SaveChanges();
        }
        else
        {
            Console.WriteLine("data is already present");
        }
    }
}