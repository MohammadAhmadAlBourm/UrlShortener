using Application.Features.ShortenedUrls.Commands.Create;
using Application.Features.ShortenedUrls.Commands.Delete;
using Application.Features.ShortenedUrls.Queries.GetByCode;
using Application.Features.ShortenedUrls.Queries.GetById;
using Application.Features.ShortenedUrls.Queries.GetMyUrls;
using Application.Features.ShortenedUrls.Queries.GetShortenedUrls;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.Shortener;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
           .HasApiVersion(new ApiVersion(1))
           .HasApiVersion(new ApiVersion(2))
           .ReportApiVersions()
           .Build();

        app.MapPost("api/shorten", async (CreateShorterUrlCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapDelete("api/v{version:apiVersion}/shorten/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new DeleteShorterUrlCommand(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapGet("api/v{version:apiVersion}/shorten/code/{code}", async (string code, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetByCodeQuery(code), cancellationToken);
            return response.IsSuccess ? Results.Redirect(response.Value.LongUrl) : response.ToProblemDetails();
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1);

        app.MapGet("api/v{version:apiVersion}/shorten/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetByIdQuery(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapGet("api/v{version:apiVersion}/shorten/my-url", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetMyUrlsQuery(), cancellationToken);
            return Results.Ok(response);
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapGet("api/v{version:apiVersion}/shorten", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetShortenedUrlsQuery(), cancellationToken);
            return Results.Ok(response);
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();


    }
}