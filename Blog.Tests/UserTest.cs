using Blog_Dirty_;
using Microsoft.VisualBasic.FileIO;

namespace Blog.Tests
{
    [TestFixture]
    public class Tests
    {
        private string username = "username";
        private string password = "password";
        [SetUp]
        public void Setup()
        {
        }
        

        [Test]
        public void usernameTest()
        {
            User user = new User(username, password);

            Assert.Pass(user.UserName = username);
        }
        [Test]
        public void passwordTest()
        {
            User user = new User(username, password);

            Assert.Pass(user.Password = password);
        }
    }
}