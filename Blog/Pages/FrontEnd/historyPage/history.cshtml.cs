using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Blog.Database;

namespace Blog.Pages.FrontEnd.historyPage
{
    public class historyModel : PageModel
    {
        public void OnGet()
        {
            DatabaseManagement databaseManagement = new DatabaseManagement("");

            //databaseManagement.getValue();
        }
    }
}
