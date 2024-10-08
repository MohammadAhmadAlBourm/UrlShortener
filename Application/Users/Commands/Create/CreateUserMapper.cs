﻿using Domain.Entities;
using Mapster;

namespace Application.Users.Commands.Create;

internal static class CreateUserMapper
{
    public static void Configure()
    {
        TypeAdapterConfig<CreateUserCommand, User>.NewConfig();
        TypeAdapterConfig<User, CreateUserResponse>.NewConfig();
    }
}