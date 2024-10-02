using Azure.Core;
using Blog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.FrontEnd.blogPage
{
    public class blogModel : PageModel
    {
        public void OnGet()
        {
            
        }
        protected void Submit(object sender, EventArgs e)
        {
            string blogData = Request.Form["blogContainment"];
            DatabaseManagement databaseManagement = new DatabaseManagement("");
            databaseManagement.addValue();
        }
    }
}
