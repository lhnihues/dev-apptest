using DevAppTest.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DevAppTest.Models
{
    public class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                // Look for any users.
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                var user = new ApplicationUser
                {
                    UserName = "teste",
                    Email = "teste@exemplo.com",
                    EmailConfirmed = true
                };

                var return1 = await userManager.CreateAsync(user, "Senha#123");

                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@exemplo.com",
                    EmailConfirmed = true
                };

                var return2 = await userManager.CreateAsync(admin, "Admin#123");

                await context.SaveChangesAsync();
            }
        }
    }
}
