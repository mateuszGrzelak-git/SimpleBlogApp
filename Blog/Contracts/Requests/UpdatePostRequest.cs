namespace Blog.Contracts.Requests;

public class UpdatePostRequest
{
    public Guid Id { get; init; }

    public string PostName { get; init; } = default!;

    public string PostData { get; init; } = default!;
    public string username { get; init; } = default!;
}
