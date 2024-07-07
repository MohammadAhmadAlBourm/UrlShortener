namespace Application.Features.Authentication.Queries.GetProfile;

public sealed class GetProfileResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = [];
    public DateTime CreatedDate { get; set; }
}