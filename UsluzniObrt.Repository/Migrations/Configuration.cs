namespace UsluzniObrt.Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UsluzniObrt.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<UsluzniObrtDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UsluzniObrtDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }
        private void InitializeIdentityForEF(UsluzniObrtDbContext context)
        {
            var UserManager = new UserManager<User>(new UserStore<User>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string name = "Admin@admin.com";
            string password = "123456";
            string test = "test";

            //Create Role Test and User Test
            RoleManager.Create(new IdentityRole(test));
            UserManager.Create(new User() { UserName = test });

            //Create Role Admin if it does not exist
            if (!RoleManager.RoleExists(name))
            {
                var roleresult = RoleManager.Create(new IdentityRole(name));
            }

            //Create User=Admin with password=123456
            var user = new User();
            user.UserName = name;
            user.Email = name;
            var adminresult = UserManager.Create(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = UserManager.AddToRole(user.Id, name);
            }
        }
    }
}
