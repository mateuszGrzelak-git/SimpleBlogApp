using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Dirty_
{
    public class Posts
    {
        /// <summary>
        /// Class <c>Posts</c> represent post in application
        /// <list type="bullet">
        /// <item><param name="postName">name of the post</param></item>
        /// <item><param name="postData">stores the post data</param></item>
        /// </list>
        /// </summary>
        public Posts(string postName, string postData)
        {
            this.postName = postName;
            this.postData = postData;
        }

        /// <summary>
        /// Gets or sets the name of the post
        /// </summary>
        public string postName { get; set; }
        /// <summary>
        /// Gets or sets the data of the post
        /// </summary>
        public string postData { get; set; }
        /// <summary>
        /// Gets or sets the owner of the post
        /// </summary>
        public string username { get; set; }
    }
}
