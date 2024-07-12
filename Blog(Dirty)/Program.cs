using Blog_Dirty_;

namespace Blog_Dirty_
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write a username: ");
            string username = Console.ReadLine();
            Console.Write("Write a password: ");
            string password = Console.ReadLine();

            User user = new User(username, password);

            UserManager userManager = new UserManager();

            userManager.addUser(username, password);
            Console.WriteLine("User created sucessfully");
            userManager.removeUser(user);
            Console.WriteLine("User removed successfully");

            BlogInterface blogInterface = new BlogInterface();

            blogInterface.menu();
            
        }
    }

}