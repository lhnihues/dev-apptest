using DevAppTest.Data;
using DevAppTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectStr = builder.Configuration.GetConnectionString("Database");

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<Contexto>
//    (options => options.UseMySql(connectStr, ServerVersion.AutoDetect(connectStr)));

//Authentication
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseMySql(connectStr, ServerVersion.AutoDetect(connectStr)));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Seed the database with test data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    DbInitializer.Initialize(services, userManager).Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapRazorPages();

app.Run();
