namespace ChooseMe.Data.Migrations
{
    using ChooseMe.Web.Data;
    using Common.Constants;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Linq;

    public class SeedDb
    {
        public void Start(ChooseMeDbContext context)
        {
            SeedUsers(context);
        }

        private void SeedUsers(ChooseMeDbContext context)
        {
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //Create Role if it does not exist
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole(ControllersConst.AdminRole));
                roleManager.Create(new IdentityRole(ControllersConst.AdopterRole));
                roleManager.Create(new IdentityRole(ControllersConst.OrganizationRole));
            }

            if (!context.Users.Any())
            {
                CreateNewUser(userManager, roleManager, ControllersConst.AdminRole, "admin@test.com", "123456");
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