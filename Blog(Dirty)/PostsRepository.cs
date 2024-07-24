using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Blog_Dirty_
{
    /// <summary>
    /// Class <c>PostsRepository</c> stores all data about posts in sql
    /// </summary>
    public class PostsRepository : RepositoryModel
    {
        public PostsRepository() : base("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True")
        {

        }
    }
}
