using Application.Features.Authentication.Commands.Login;
using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries.GetProfile;
using Carter;
using Domain.Abstractions;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.Authentication;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/register", async (RegisterCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<RegisterResponse> response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        });

        app.MapPost("api/auth/login", async (LoginCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<LoginResponse> response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        });

        app.MapGet("api/auth/profile", async (ISender sender, CancellationToken cancellationToken) =>
        {
            Result<GetProfileResponse> response = await sender.Send(new GetProfileQuery(), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        }).RequireAuthorization();
    }
}