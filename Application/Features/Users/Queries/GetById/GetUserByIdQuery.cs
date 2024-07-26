using Application.Abstractions.Messaging;

namespace Application.Features.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResponse>;