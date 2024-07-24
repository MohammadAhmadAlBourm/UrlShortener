using Application.Features.ShortenedUrls.Commands.Create;
using Application.Features.ShortenedUrls.Commands.Delete;
using Application.Features.ShortenedUrls.Queries.GetByCode;
using Application.Features.ShortenedUrls.Queries.GetById;
using Application.Features.ShortenedUrls.Queries.GetMyUrls;
using Application.Features.ShortenedUrls.Queries.GetShortenedUrls;
using Carter;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.Shortener;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/shorten", async (CreateShorterUrlCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();

        app.MapDelete("api/shorten/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new DeleteShorterUrlCommand(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();

        app.MapGet("api/shorten/code/{code}", async (string code, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetByCodeQuery(code), cancellationToken);
            return response.IsSuccess ? Results.Redirect(response.Value.LongUrl) : response.ToProblemDetails();
        });

        app.MapGet("api/shorten/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetByIdQuery(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        }).RequireAuthorization();

        app.MapGet("api/shorten/my-url", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetMyUrlsQuery(), cancellationToken);
            return Results.Ok(response);
        }).RequireAuthorization();

        app.MapGet("api/shorten", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetShortenedUrlsQuery(), cancellationToken);
            return Results.Ok(response);
        }).RequireAuthorization();

    }
}