namespace ChooseMe.Data.Migrations
{
    using ChooseMe.Web.Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Linq;

    class SeedDb
    {
        public static void Start(ChooseMeDbContext context)
        {
            SeedUsers(context);
        }

        private static void SeedUsers(ChooseMeDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create Role if it does not exist
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole("Admin"));
                roleManager.Create(new IdentityRole("Adopter"));
                roleManager.Create(new IdentityRole("Organization"));
            }

            if (!context.Users.Any())
            {
                CreateNewUser(userManager, roleManager, "Admin", "admin@test.com", "123456");
            }
        }

        private static void CreateNewUser(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, string name, string email, string password)
        {
            //Create User with password
            var user = new User();
            user.UserName = "admin";
            user.Email = email;
            var adminresult = userManager.Create(user, password);

            //Add User to Role
            if (adminresult.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, name);
            }
        }
    }
}