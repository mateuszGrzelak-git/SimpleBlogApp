using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Dirty_
{
    public class User
    {
        public User(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
