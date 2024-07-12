using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Dirty_;

namespace Blog.Tests
{
    [TestFixture]
    public class UserManagerTest
    {
        private string username = "Jhon";
        private string password = "password";
        private UserManager userManager;
        private void createManager()
        {
            if (userManager == null)
            {
                userManager = new UserManager();
            }
            else
            {
                return;
            }

        }
        [Test]
        public void isUsernameFreeTest()
        {

            string example = "Mike";
            createManager();

            Assert.IsTrue(userManager.isUsernameFree(example));
        }

        [Test]
        public void addUserTest()
        {
            createManager();

            userManager.addUser(username, password);

            Assert.IsFalse(userManager.isUsernameFree(username));
        }

        [Test]
        public void removeUserTest()
        {
            createManager();
            User user = new User(username, password);

            userManager.removeUser(user);
            
        }
    }
}
