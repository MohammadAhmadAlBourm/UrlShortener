using Application.Abstractions;

namespace Application.Features.Authentication.Queries.GetProfile;

public sealed record GetProfileQuery() : IQuery<GetProfileResponse>;