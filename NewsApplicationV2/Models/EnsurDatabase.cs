using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsApplicationV2.Models
{
    public static class EnsurDatabase
    {
        private const string adminRole = "Admin";
        private const string userRole = "User";

        private const string adminName = "Admin";
        private const string userName = "User";

        private const string password = "Secret123$";

        public static void Migrate(IApplicationBuilder app)
        {
            var ctx = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<AppDbContext>();

            if (ctx.Database.GetPendingMigrations().Any())
            {
                ctx.Database.Migrate();
            }
        }
        public async static void SeedDefaultAccounts(IApplicationBuilder app)
        {
            var roleManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RoleManager<AppRole>>();

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                var role = new AppRole { Name = adminRole };
                await roleManager.CreateAsync(role);
            }
            if (!await roleManager.RoleExistsAsync(userRole))
            {
                var role = new AppRole { Name = userRole };
                await roleManager.CreateAsync(role);
            }

            var userManager = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<UserManager<AppUser>>();

            var admin = await userManager.FindByNameAsync(adminName);
            if (admin == null)
            {
                admin = new AppUser { UserName = adminName };
                await userManager.CreateAsync(admin, password);
                await userManager.AddToRolesAsync(admin, [adminRole, userRole]);
            }
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                user = new AppUser { UserName = userName };
                await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, userRole);

            }
        }
    }
}
