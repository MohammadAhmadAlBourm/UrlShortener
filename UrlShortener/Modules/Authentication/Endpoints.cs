using Application.Features.Authentication.Commands.Login;
using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Queries.GetProfile;
using Asp.Versioning;
using Asp.Versioning.Builder;
using Carter;
using Domain.Abstractions;
using MediatR;
using UrlShortener.Extensions;

namespace UrlShortener.Modules.Authentication;

public class Endpoints : CarterModule
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        ApiVersionSet apiVersionSet = app.NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .HasApiVersion(new ApiVersion(2))
            .ReportApiVersions()
            .Build();


        app.MapPost("api/v{version:apiVersion}/auth/register", async (RegisterCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<RegisterResponse> response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1);

        app.MapPost("api/v{version:apiVersion}/auth/login", async (LoginCommand request, ISender sender, CancellationToken cancellationToken) =>
        {
            Result<LoginResponse> response = await sender.Send(request, cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();
        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1);


        app.MapGet("api/v{version:apiVersion}/auth/profile", async (ISender sender, CancellationToken cancellationToken) =>
        {
            Result<GetProfileResponse> response = await sender.Send(new GetProfileQuery(), cancellationToken);
            return response.IsSuccess ? Results.Ok(response.Value) : response.ToProblemDetails();

        })
        .WithApiVersionSet(apiVersionSet)
        .MapToApiVersion(1)
        .RequireAuthorization();
    }
}