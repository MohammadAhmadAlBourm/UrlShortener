using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetUsers;
using Carter;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.User;

public class Endpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/user", async (CreateUserCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();

        app.MapDelete("api/user", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new DeleteUserCommand(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();


        app.MapPut("api/user", async (UpdateUserCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();


        app.MapGet("api/user/{id}", async (Guid id, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetUserByIdQuery(id), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();


        app.MapGet("api/user", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetUsersQuery(), cancellationToken);
            return Results.Ok(response);

        }).RequireAuthorization();

    }
}