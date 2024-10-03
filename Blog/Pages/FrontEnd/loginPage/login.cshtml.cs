using Blog.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.FrontEnd.loginPage
{
    public class loginModel : PageModel
    {
        public void OnGet()
        {
        }

        protected void Submit(object sender, EventArgs e)
        {
            string login = Request.Form["login"];
            string password = Request.Form["password"];
            DatabaseManagement databaseManagement = new DatabaseManagement("");
            //databaseManagement.addValue();
        }
    }
}
