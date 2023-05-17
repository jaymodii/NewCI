using Microsoft.EntityFrameworkCore;
using NewCI.Entities.Data;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabasewithDataContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(25);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseStatusCodePages(async context => {
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized || response.StatusCode == (int)HttpStatusCode.Forbidden)
    {
        response.Redirect("/User/LoginPage");
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=LoginPage}/{id?}");


app.Run();