using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Dirty_;

namespace Blog.Tests
{
    [TestFixture]
    public class PostsRepositoryTest
    {
        private PostsRepository postsRepository;
        private void createRepo()
        {
            if (postsRepository==null)
            {
                postsRepository = new PostsRepository();
            }
            else
            {
                return;
            }

        }
        [Test]
        public void executeDataAdapterTest()
        {
            createRepo();
            DataTable dataTable = new DataTable();
            string databaseCommands = "";
            Assert.Throws<NullReferenceException>(() => { postsRepository.executeDataAdapter(dataTable, databaseCommands); });
        }
        [Test]
        public void readDataFromCommands()
        {
            createRepo();
            DataTable dataTable = new DataTable();
            string commands = "";
            Assert.Throws<InvalidOperationException>(() => { postsRepository.readDataFromCommands(commands, dataTable); });
        }

        [Test]
        public void executeQueryTest()
        {
            createRepo();
            string databaseCommands = "";

            SqlCommand sqlCommand = new SqlCommand(databaseCommands);
            Assert.Throws<InvalidOperationException>(() => { postsRepository.executeQuery(sqlCommand); });
        }
    }
}
