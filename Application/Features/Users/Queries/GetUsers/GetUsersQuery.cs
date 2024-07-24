using MediatR;

namespace Application.Features.Users.Queries.GetUsers;

public sealed record GetUsersQuery() : IRequest<IEnumerable<GetUsersResponse>>;