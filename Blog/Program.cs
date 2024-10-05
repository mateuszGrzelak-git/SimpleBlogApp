using Blog.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

string connectionString = "Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;encrypt=false";
DatabaseTest databaseTest = new DatabaseTest();
databaseTest.isDatabaseExists(connectionString);
//string connectionString = "Data Source=(local)\\POSTSDATABASE;Initial Catalog=OnlinePosts;Integrated Security=True"

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
