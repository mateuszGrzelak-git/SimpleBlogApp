namespace Blog.Contracts.Requests;

public class UpdateUserRequest
{
    public Guid Id { get; init; }

    public string Username { get; init; } = default!;

    public string Password { get; init; } = default!;
}
