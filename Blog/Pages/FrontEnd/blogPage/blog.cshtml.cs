using Blog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.FrontEnd.blogPage
{
    public class blogModel : PageModel
    {
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

            if(databaseManagement.getValue(1)==null)
            {
                RedirectToPage("/FrontEnd/homePage/home");
            }

            databaseManagement.addValue("Admin", "Default", BlogData);

            return RedirectToPage("/FrontEnd/homePage/home"); // lub inna akcja po zapisie danych
        }

    }
}
