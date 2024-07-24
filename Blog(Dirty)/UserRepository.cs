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
    /// Class <c>UserRepository</c> stores all data about posts in sql
    /// </summary>
    public class UserRepository : RepositoryModel
    {
        public UserRepository() : base("Data Source=(local)\\USERDATABASE;Initial Catalog=UserRepository;Integrated Security=True")
        {

        }
    }
}
