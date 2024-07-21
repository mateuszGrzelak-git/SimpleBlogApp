namespace Blog.Contracts.Requests;

public class CreatePostRequest
{
    public string PostName { get; init; } = default!;

    public string PostData { get; init; } = default!;
    public string Username { get; init; } = default!;
}
