using Carter;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Database;
using UrlShortener.Entities;
using UrlShortener.Models;

namespace UrlShortener.Modules.Shortener;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/shorten", async ([AsParameters] ShortenerUrlRequestParameters data, CancellationToken cancellationToken) =>
        {
            if (!Uri.TryCreate(data.Request.Url, UriKind.Absolute, out _))
            {
                return Results.BadRequest();
            }
            var code = await data.UrlShorteningService.GenerateUniqueCode();

            var shortenedUrl = new ShortenedUrl()
            {
                Id = Guid.NewGuid(),
                LongUrl = data.Request.Url,
                ShortUrl = $"{data.HttpContext.Request.Scheme}://{data.HttpContext.Request.Host}/api/{code}",
                Code = code,
                CreatedDate = DateTime.Now,
            };

            data.ApplicationDbContext.ShortenedUrls.Add(shortenedUrl);
            await data.ApplicationDbContext.SaveChangesAsync(cancellationToken);

            return Results.Ok(shortenedUrl);
        });


        app.MapGet("api/{code}", async (string code, ApplicationDbContext context, CancellationToken cancellationToken) =>
        {
            var shortenedUrl = await context.ShortenedUrls
                .FirstOrDefaultAsync(x => x.Code == code, cancellationToken);

            if (shortenedUrl is null)
            {
                return Results.NotFound();
            }

            return Results.Redirect(shortenedUrl.LongUrl);
        });
    }
}