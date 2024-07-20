using Domain.Abstractions;

namespace Domain.Entities;

public static class UserErrors
{
    public static readonly Error UserEmailAlreadyExist = new("User.Email", "User already Exist");
    public static readonly Error UserIdNotFound = new("User.Id", "User was not found");
    public static readonly Error UserEmailNotFound = new("User.Email", "User was not found");
    public static readonly Error UserPasswordNotMatching = new("User.Password", "User Password Not Matching");
    public static readonly Error NotSavedSuccessfully = new("User.Save", "An Issue occurred while saving the user");
}