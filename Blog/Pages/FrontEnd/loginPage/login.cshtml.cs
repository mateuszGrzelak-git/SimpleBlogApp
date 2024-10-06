using Blog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.FrontEnd.loginPage
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return RedirectToPage("/FrontEnd/errorPage/error");
            }

            DatabaseManagement databaseManagement = new DatabaseManagement("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;encrypt=false");

            Console.WriteLine(Username);
            Console.WriteLine(Password);
            databaseManagement.addValue(Username, Password);

            return RedirectToPage("/FrontEnd/blogPage/blog"); // lub inna akcja po zapisie danych
        }
    }
}
