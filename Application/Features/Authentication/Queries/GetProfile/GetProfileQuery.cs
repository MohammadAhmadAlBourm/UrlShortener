using MediatR;

namespace Application.Features.Authentication.Queries.GetProfile;

public sealed record GetProfileQuery() : IRequest<GetProfileResponse>;