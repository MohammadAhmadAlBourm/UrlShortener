using Domain.Entities;
using Mapster;

namespace Application.Users.Queries.GetUsers;

internal static class GetUsersMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetUsersResponse>.NewConfig();
    }
}