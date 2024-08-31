using Application.Abstractions.Messaging;

namespace Application.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResponse>;