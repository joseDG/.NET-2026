using Microsoft.AspNetCore.Identity;

namespace AppStore.Models.Domain
{
    public static class LoadDatabase
    {
                public static async Task CrearRolesYAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "Usuario" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string emailAdmin = "admin@empresa.com";
            string passwordAdmin = "Admin12345";

            var admin = await userManager.FindByEmailAsync(emailAdmin);

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = emailAdmin,
                    Email = emailAdmin,
                };

                await userManager.CreateAsync(admin, passwordAdmin);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}