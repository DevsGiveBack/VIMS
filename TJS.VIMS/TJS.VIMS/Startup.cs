using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using TJS.VIMS.Models;

[assembly: OwinStartupAttribute(typeof(TJS.VIMS.Startup))]
namespace TJS.VIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesUsers();
        }


        // In this method we will create default User roles and Admin user for login
        private void createRolesUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User 
            if (!roleManager.RoleExists("Employee") && !roleManager.RoleExists("Administrator"))
            {
                //create roles
                var role1 = new IdentityRole();
                role1.Name = "Employee";
                roleManager.Create(role1);

                var role2 = new IdentityRole();
                role2.Name = "Administrator";
                roleManager.Create(role2);

                //Here we create a Admin super user who will maintain the website				

                var user = new ApplicationUser();
                user.UserName = "AdminUser";
                user.Email = "AdminUser";

                string userPWD = "Test@123";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Employee");
                    var result2 = UserManager.AddToRole(user.Id, "Administrator");
                }
            }

            //// creating Creating Manager role 
            //if (!roleManager.RoleExists("Administrator"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Administrator";
            //    roleManager.Create(role);

            //}

            //// creating Creating Employee role 
            //if (!roleManager.RoleExists("Employee"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Employee";
            //    roleManager.Create(role);

            //}
        }
    }
}
