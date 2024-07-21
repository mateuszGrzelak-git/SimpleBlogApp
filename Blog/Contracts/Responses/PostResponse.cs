namespace Blog.Contracts.Responses;

public class UserResponse
{
    public Guid Id { get; init; }

    public string Username { get; init; } = default!;

    public string Password { get; init; } = default!;
}
