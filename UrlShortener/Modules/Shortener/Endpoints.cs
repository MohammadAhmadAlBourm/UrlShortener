using Application.Features.ShortenedUrls.Commands.Create;
using Application.Features.ShortenedUrls.Queries.GetByCode;
using Carter;
using MediatR;

namespace UrlShortener.Modules.Shortener;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/shorten", async (CreateShorterUrlCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return Results.Ok(response);

        }).RequireAuthorization();


        app.MapGet("api/{code}", async (string code, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetByCodeQuery(code), cancellationToken);
            return Results.Redirect(response.LongUrl);
        });
    }
}