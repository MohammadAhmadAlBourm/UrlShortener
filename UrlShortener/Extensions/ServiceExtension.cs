using Carter;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Database;
using UrlShortener.Services;

namespace UrlShortener.Extensions;

public static class ServiceExtension
{
    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(o =>
            o.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

        builder.Services.AddScoped<IUrlShorteningService, UrlShorteningService>();

        builder.Services.AddCarter();
    }
}