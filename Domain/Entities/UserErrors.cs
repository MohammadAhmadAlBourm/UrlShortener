using Domain.Abstractions;

namespace Domain.Entities;

public static class UserErrors
{
    public static Error NotFound(Guid id) => Error.NotFound(
            "User.NotFound",
            $"The User item with the Id = '{id}' was not found");

    public static Error NotFound() => Error.NotFound(
        "User.NotFound",
        "The User item was not found");
    public static Error UserPasswordNotMatching() => Error.Conflict(
        "User.UserPasswordNotMatching",
        "The User password not matching");

    public static Error UserEmailAlreadyExist(string email) => Error.Conflict(
        "User.EmailAlreadyExist",
        $"The User item with the email = '{email}' already exist");
}