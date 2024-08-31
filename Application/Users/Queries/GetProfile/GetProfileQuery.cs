using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetProfile;

public sealed record GetProfileQuery() : IQuery<GetProfileResponse>;