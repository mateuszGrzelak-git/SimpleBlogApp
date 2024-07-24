using Blog_Dirty_;

namespace Blog_Dirty_
{
    sealed class Program
    {
        static void initDatabases(string connectionString)
        {
            var connectionFactory = new SqlConnectionFactory(connectionString);

            var databaseInitializer = new DatabaseInitializer(connectionFactory);

            databaseInitializer.InitializeAsync();
        }
        static void Main(string[] args)
        {
            initDatabases("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True");
            initDatabases("Data Source=(local)\\USERDATABASE;Initial Catalog=UserRepository;Integrated Security=True");


            Console.Write("Write a username: ");
            string username = Console.ReadLine();
            Console.Write("Write a password: ");
            string password = Console.ReadLine();

            User user = new User(username, password);

            UserManager userManager = new UserManager();

            BlogInterface blogInterface = new BlogInterface(user);

            blogInterface.menu();
            
        }
    }

}