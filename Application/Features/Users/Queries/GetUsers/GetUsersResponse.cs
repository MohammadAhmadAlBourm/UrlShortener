using Domain.Enums;

namespace Application.Features.Users.Queries.GetUsers;

public sealed class GetUsersResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public List<Role> Roles { get; set; } = [];
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}