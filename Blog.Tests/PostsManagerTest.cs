using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Dirty_;

namespace Blog.Tests
{
    [TestFixture]
    public class PostsManagerTest
    {
        private string postName = "Post";
        private string postData = "DataPost";
        private string username = "admin";
        private string password = "password";
        private User user;
        private PostsManager postsManager;
        private void createManager()
        {
            if (postsManager == null)
            {
                postsManager = new PostsManager();
            }
            else
            {
                return;
            }

        }
        [Test]
        public void isPostExistsTest()
        {

            string example = "Mike";
            createManager();

            Assert.IsTrue(postsManager.isPostExists(example));
        }

        [Test]
        public void addPostTest()
        {
            createManager();

            user = new User(username, password);

            postsManager.addPost(user, postName, postData);

            Assert.IsFalse(postsManager.isPostExists(postName));
        }

        [Test]
        public void removePostTest()
        {
            createManager();
            User user = new User(username, password);

            Posts posts = new Posts(postName, postData);


            Assert.Throws<Exception>(() => postsManager.removePost(posts));

            Assert.IsFalse(postsManager.isPostExists(postName));
        }

        [Test]
        public void searchForUserPostsTest()
        {
            createManager();

            User user = new User(username, password);

            Posts posts = new Posts(postName, postData);

            postsManager.addPost(user, postName, postData);

            Assert.AreEqual(postsManager.searchForUserPosts(username).Length,1);
        }

        [Test]
        public void searchForSpecifiedPostsTest()
        {
            createManager();

            User user = new User(username, password);

            Posts posts = new Posts(postName, postData);

            postsManager.addPost(user, postName, postData);

            Assert.AreEqual(postsManager.searchForSpecifiedPost(username, postName).Length,1);
        }
    }
}
