using Domain.Entities;
using Mapster;

namespace Application.Users.Queries.GetById;

internal static class GetUserByIdMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<User, GetUserByIdResponse>.NewConfig();
    }
}