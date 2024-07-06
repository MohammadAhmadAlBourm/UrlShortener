using Carter;

namespace UrlShortener.Extensions;

public static class MiddlewareExtension
{
    public static void ConfigureMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.ApplyMigration();
        }

        app.MapCarter(); // <-- And this
        app.UseHttpsRedirection();
    }
}