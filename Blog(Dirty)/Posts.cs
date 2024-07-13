using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Dirty_
{
    public class Posts
    {
        public Posts(string postName, string postData)
        {
            this.postName = postName;
            this.postData = postData;
        }

        public string postName { get; set; }
        public string postData { get; set; }
        public string username { get; set; }
    }
}
