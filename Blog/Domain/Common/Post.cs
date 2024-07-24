using System.Security.Cryptography;
using System.Text;

namespace Blog.Domain.Common
{
    public class Post
    {
        public string postName { get; init; } = default!;
        public string postData { get; init; } = default!;
        public string username { get; init; } = default!;
    }
}
