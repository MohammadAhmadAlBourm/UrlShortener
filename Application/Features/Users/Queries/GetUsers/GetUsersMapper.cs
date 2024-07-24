using Domain.Entities;
using Mapster;

namespace Application.Features.Users.Queries.GetUsers;

internal static class GetUsersMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetUsersResponse>.NewConfig();
    }
}