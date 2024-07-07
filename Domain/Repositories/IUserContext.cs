namespace Domain.Repositories;

public interface IUserContext
{
    bool IsAuthenticated { get; }
    Guid UserId { get; }
}