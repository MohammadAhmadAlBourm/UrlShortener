using Microsoft.EntityFrameworkCore;
using UrlShortener.Database;

namespace UrlShortener.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigration(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}