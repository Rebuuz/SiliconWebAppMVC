using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositiories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//database service
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

//identity
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

//other services
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AddressManager>();

//cookie
builder.Services.ConfigureApplicationCookie(x =>
{
    //hinders others from reading the cookie information
    x.Cookie.HttpOnly = true;
    //path for sign in if not alredy signed in and trying to access account page
    x.LoginPath = "/signin";
    //authorize - protecting pages that should not be accessable when not signed in
    x.LogoutPath = "/signout";
    //user gets automatically signed out after 60 minutes and have to sign in again
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    //if user has been inactive and then become active again within 60minuites, time resets.
    x.SlidingExpiration = true;
    //requires https - standard
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

var app = builder.Build();

//app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthentication();
app.UseUserSessionValidation();
app.UseAuthorization();




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
