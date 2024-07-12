using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Blog_Dirty_
{
    
    sealed class BlogInterface
    {
        public BlogInterface()
        {
            
        }

        private void writerMode()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("W: ");
        }

        private void readerMode()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("R: ");
        }

        private void defaultMode()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void writeBlogPost()
        {

            string blogName;
            bool exit = false;
            string blogData;

            Console.WriteLine();

            Console.WriteLine("To end writing type exit in new line");
            Console.Write("Write the name of your new blog: ");
            blogName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("\t" + blogName + "\n\n\n\n\n");

            while (!exit)
            {
                writerMode();
                blogData = Console.ReadLine();

                if (blogData == "exit")
                {
                    exit = true;
                }

            }
            defaultMode();
        }

        public void readBlogPost()
        {
            readerMode();



            defaultMode();
        }

        public void menu()
        {
            ConsoleKeyInfo option;

            Console.WriteLine("Welcome in BlogApp!!!\n\n\n");

            Console.WriteLine("Select the option from below");

            Console.WriteLine("a. Write a blog post");
            Console.WriteLine("b. Read your blog posts");
            Console.WriteLine("c. Read specified post");
            Console.Write("Your option: ");

            option = Console.ReadKey();

            if (ConsoleKey.A == option.Key)
            {
                writeBlogPost();   
            }
            else if(ConsoleKey.B == option.Key)
            {

            }
            else if(ConsoleKey.C == option.Key)
            {

            }
        }
    }
}
