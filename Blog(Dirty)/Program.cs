using Blog_Dirty_;

namespace Blog_Dirty_
{
    sealed class Program
    {
        private static UserManager userManager = new UserManager();
        static void Main(string[] args)
        {
            Console.Write("Write a username: ");
            string username = Console.ReadLine();
            Console.Write("Write a password: ");
            string password = Console.ReadLine();
        }
    }

}