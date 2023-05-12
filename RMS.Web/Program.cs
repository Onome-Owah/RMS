using Microsoft.AspNetCore.Authentication.Cookies;
using RMS.Data.Services;
using RMS.Web;

// NOTE: Changes needed here to enable Authentication Stretch Requirement
var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddSingleton<IUserService,UserServiceDb>();
builder.Services.AddScoped<IRecipeService,RecipeServiceDb>();

// ** add authentication service using Cookie Scheme **
builder.Services.AddCookieAuthentication();

   
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} 
else 
{
    // in development mode seed the database each time the application starts  
    using (var scope = app.Services.CreateScope())
    {
        ServiceSeeder.Seed(
            scope.ServiceProvider.GetService<IUserService>(), 
            scope.ServiceProvider.GetService<IRecipeService>()
        );
    }
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
