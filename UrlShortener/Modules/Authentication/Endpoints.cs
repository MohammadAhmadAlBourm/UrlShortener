using Application.Features.Authentication.Commands.Login;
using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries.GetProfile;
using Carter;
using MediatR;

namespace UrlShortener.Modules.Authentication;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/register", async (RegisterCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return Results.Ok(response);
        });

        app.MapPost("api/auth/login", async (LoginCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(request, cancellationToken);
            return Results.Ok(response);
        });

        app.MapGet("api/auth/profile", async (ISender sender, CancellationToken cancellationToken) =>
        {
            var response = await sender.Send(new GetProfileQuery(), cancellationToken);
            return Results.Ok(response);

        }).RequireAuthorization();
    }
}