namespace Application.Features.Authentication.Commands.Login;

public sealed class LoginResponse
{
    public string Token { get; set; } = string.Empty;
}