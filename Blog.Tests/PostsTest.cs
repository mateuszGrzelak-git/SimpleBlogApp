using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Dirty_;

namespace Blog.Tests
{
    [TestFixture]
    public class PostsTest
    {
        [Test]
        public void postNameTest()
        {
            string postName = "Jhon";
            string postData = "";
            Posts posts = new Posts(postName, postData);

            Assert.Pass(posts.postName = postName);
        }
        [Test]
        public void postDataTest()
        {
            string postName = "";
            string postData = "Data";
            Posts posts = new Posts(postName, postData);

            Assert.Pass(posts.postData = postData);
        }
    }
}
