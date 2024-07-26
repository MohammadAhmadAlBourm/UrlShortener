using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetUsers;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.User;

public class Endpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .HasApiVersion(new ApiVersion(2))
            .ReportApiVersions()
            .Build();

        app.MapPost("api/v{version:apiVersion}/user", async (CreateUserCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapDelete("api/v{version:apiVersion}/user", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new DeleteUserCommand(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapPut("api/v{version:apiVersion}/user", async (UpdateUserCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapGet("api/v{version:apiVersion}/user/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetUserByIdQuery(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();

        app.MapGet("api/v{version:apiVersion}/user", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetUsersQuery(), cancellationToken);
            return Results.Ok(response);

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();
    }
}