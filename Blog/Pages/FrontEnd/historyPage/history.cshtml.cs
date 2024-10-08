using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.Database;
using System.Collections.Generic;

namespace Blog.Pages.FrontEnd.historyPage
{
    public class HistoryModel : PageModel
    {
        [BindProperty]
        public List<string> Users { get; set; } = new List<string>();

        [BindProperty]
        public List<string> Blogs { get; set; } = new List<string>();

        private readonly DatabaseManagement _databaseManagement;

        public HistoryModel()
        {
            _databaseManagement = new DatabaseManagement("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;encrypt=false");
        }

        public void OnGet()
        {
            // You can initialize values on page load if needed.
        }

        public IActionResult OnPost()
        {
            // Retrieve values from the database and populate Users and Blogs lists
            Users = _databaseManagement.GetUsersHistory(); // assuming you have a method to fetch user history
            Blogs = _databaseManagement.GetBlogsHistory(); // assuming you have a method to fetch blog history

            return Page();
        }
    }
}
