using Domain.Entities;
using Mapster;

namespace Application.Features.Users.Commands.Update;

internal static class UpdateUserMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<UpdateUserCommand, User>.NewConfig();
        TypeAdapterConfig<User, UpdateUserResponse>.NewConfig();
    }
}