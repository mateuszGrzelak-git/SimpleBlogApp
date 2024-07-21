namespace Blog.Contracts.Requests;

public class CreateUserRequest
{
    public string Username { get; init; } = default!;

    public string Password { get; init; } = default!;
}
