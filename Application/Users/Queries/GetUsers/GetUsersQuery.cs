using MediatR;

namespace Application.Users.Queries.GetUsers;

public sealed record GetUsersQuery() : IRequest<IEnumerable<GetUsersResponse>>;