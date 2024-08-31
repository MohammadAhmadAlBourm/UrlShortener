namespace Domain.Entities;

public class EmailVerificationToken
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpiryDateTime { get; set; }
    public User User { get; set; }
}