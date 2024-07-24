using Application.Abstractions;

namespace Application.Features.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid Id) : IQuery<GetUserByIdResponse>;