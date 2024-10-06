using Blog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace Blog.FrontEnd.blogPage
{
    public class blogModel : PageModel
    {
        [BindProperty]
        public string BlogTitle { get; set; }
        [BindProperty]
        public string BlogData { get; set; }

        public void OnGet()
        {
            // Logika dla ¿¹dania GET
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Logika dla przesy³ania formularza
            DatabaseManagement databaseManagement = new DatabaseManagement("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;encrypt=false");

            int lastId = databaseManagement.GetLastId();

            if (lastId == 0)
            {
                Console.WriteLine("Id Equal 0");
                // Obs³u¿ brak wpisów w tabeli Users (np. przekierowanie lub komunikat o b³êdzie)
                return RedirectToPage("/FrontEnd/errorPage/error");
            }

            string author = databaseManagement.getValue(lastId);

            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Author empty");
                return RedirectToPage("/FrontEnd/errorPage/error");
            }
            else
            {
                Console.WriteLine("Success");
                databaseManagement.addValue(author, BlogTitle, BlogData);

                return RedirectToPage("/FrontEnd/homePage/home"); // lub inna akcja po zapisie danych
            }
        }


    }
}
