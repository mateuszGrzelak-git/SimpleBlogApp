using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Pages.FrontEnd.readPage
{
    public class ReadModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Please enter a search term.")]
        public string Input { get; set; }

        [BindProperty]
        public List<string> Blogs { get; set; } = new List<string>();

        private readonly DatabaseManagement _databaseManagement;

        public ReadModel()
        {
            _databaseManagement = new DatabaseManagement("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;encrypt=false");
        }

        public void OnGet()
        {
            // Page load logic if needed.
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Simulating database fetching logic; append search results to Blogs.
            var blogData = _databaseManagement.getBlogData(Input);
            if (!string.IsNullOrEmpty(blogData))
            {
                Blogs.Add(blogData);
            }

            return Page();
        }
    }
}
