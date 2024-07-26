using Application.Abstractions.Messaging;

namespace Application.Features.Authentication.Queries.GetProfile;

public sealed record GetProfileQuery() : IQuery<GetProfileResponse>;