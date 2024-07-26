using Domain.Abstractions;
using Domain.Options;
using Domain.Repositories;
using Infrastructure.BackgroundJobs;
using Infrastructure.Database;
using Infrastructure.Emails;
using Infrastructure.Options;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UrlShortener.Services;

namespace Infrastructure;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructure(this IServiceCollection services)
    {
        services.ConfigureOptions<DatabaseOptionsSetUp>();


        services.AddDbContext<ApplicationDbContext>((serviceProvider, dbContextOptionBuilder) =>
        {
            var databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>()!.Value;

            dbContextOptionBuilder.UseSqlServer(databaseOptions.ConnectionString, sqlServiceAction =>
            {
                sqlServiceAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServiceAction.CommandTimeout(databaseOptions.CommandTimeout);

            });

            dbContextOptionBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            dbContextOptionBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShortenedUrlRepository, ShortenedUrlRepository>();
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IShortenedUrlContext, ShortenedUrlContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddScoped<IEmailService, EmailService>();

        services
            .AddFluentEmail("fromemail@test.test")
            .AddRazorRenderer()
            .AddSmtpSender("localhost", 25);


        services.AddHttpContextAccessor();

        services.AddHostedService<DeleteUnnecessaryUrlsBackgroundJob>();

    }
}