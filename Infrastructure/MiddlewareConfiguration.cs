using PlatformService.Data;

namespace PlatformService.Infrastructure;

public static class MiddlewareConfiguration
{
    public static WebApplication ConfigureMiddlewares(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.PrePopulation();

        return app;
    }
}