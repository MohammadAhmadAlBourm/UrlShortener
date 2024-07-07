using Domain.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.Services;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IShortenedUrlContext, ShortenedUrlContext>();

        services.AddHttpContextAccessor();
    }
}