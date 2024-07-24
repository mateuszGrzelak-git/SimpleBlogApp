using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Blog_Dirty_
{
    /// <summary>
    /// Class <c>BlogInterface</c> creates a user interaction with program
    /// </summary>
    sealed class BlogInterface
    {
        private PostsManager postsManager;
        private User user;
        public BlogInterface(User user)
        {
            postsManager = new PostsManager();
            this.user = user;
        }

        /// <summary>
        /// This method changes text color to green and writes W: before writing
        /// </summary>
        private void writerMode()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("W: ");
        }
        /// <summary>
        /// This method changes text color to red and writes R: before writing
        /// </summary>
        private void readerMode()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("R: ");
        }

        private void defaultMode()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// This method writes instructions for writer and saves content to database
        /// </summary>
        public void writeBlogPost()
        {

            string blogName;
            bool exit = false;
            string blogData = string.Empty;

            Console.WriteLine();

            Console.WriteLine("To end writing type exit in new line");
            Console.Write("Write the name of your new blog: ");
            blogName = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("\t" + blogName + "\n\n\n\n\n");

            while (!exit)
            {
                string addon = string.Empty;
                writerMode();
                addon += Console.ReadLine();

                if (addon == "exit")
                {
                    exit = true;
                    break;
                }

                addon += " ";
                blogData += addon;

            }
            defaultMode();

            if (blogData != string.Empty)
                postsManager.addPost(user, blogName, blogData);
            else
            {
                throw new Exception("No Data in post");
            }

            selectOption();
        }
        /// <summary>
        /// Outputs blog post
        /// </summary>
        /// <returns>
        /// string with usernames and posts which their owners wrote
        /// </returns>
        public void readBlogPost()
        {
            bool exit = false;
            string writerData = string.Empty;
            string blogName;

            Console.WriteLine();

            readerMode();
           
            string[] postData = postsManager.searchForUserPosts(user.UserName);

            foreach (string post in postData)
            {
                Console.WriteLine(post);
            }

           /* writerMode();

            while (!exit)
            {
                writerMode();

                string addon = string.Empty;
                addon += Console.ReadLine();

                if (addon == "exit")
                {
                    exit = true;
                    break;
                }

                addon += " ";
                writerData = addon;
            }*/

            defaultMode();
            selectOption();
        }

        /// <summary>
        /// This method makes user write two variables" 
        /// <list type="table">
        /// <item><param name="blogName">The name of blog to read</item>
        /// <item><param name="username">The name of user who created blog</param></item>
        /// </list>
        /// </summary>
        public void readSpecifiedBlogPost()
        {
            bool exit = false;
            string writerData = string.Empty;
            string blogName;
            string username;
            string[] postData;


            Console.WriteLine();
            Console.Write("Enter blog name: ");
            blogName = Console.ReadLine();
            Console.WriteLine("Enter username of creator: ");
            username = Console.ReadLine();

            readerMode();

            postData = postsManager.searchForUserPosts(user.UserName); //To be fixed

            foreach (string post in postData)
            {
                Console.WriteLine(post);
            }

            Console.WriteLine(postData);

            writerMode();

            while (!exit)
            {
                writerMode();

                string addon = string.Empty;
                addon += Console.ReadLine();

                if (addon == "exit")
                {
                    exit = true;
                    break;
                }

                addon += " ";
                writerData = addon;
            }

            defaultMode();
            selectOption();
        }
        /// <summary>
        /// selectOption make user choose what he want to do
        /// </summary>
        public void selectOption()
        {
            ConsoleKeyInfo option;
            Console.WriteLine("Select the option from below");

            Console.WriteLine("a. Write a blog post");
            Console.WriteLine("b. Read your blog posts");
            Console.WriteLine("d. Exit Program");
            Console.Write("Your option: ");

            option = Console.ReadKey();

            if (ConsoleKey.A == option.Key)
            {
                writeBlogPost();
            }
            else if (ConsoleKey.B == option.Key)
            {
                readBlogPost();
            }
            else if (ConsoleKey.D == option.Key)
            {
                return;
            }
        }

        /// <summary>
        /// This method welcome our users
        /// </summary>
        public void menu()
        {
            ConsoleKeyInfo option;

            Console.WriteLine("Welcome in BlogApp!!!\n\n\n");

            selectOption();
        }
    }
}
