using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using UsluzniObrt.Model;
using UsluzniObrt.Repository;

namespace UsluzniObrt.Service
{
    public class UserService : IUserService
    {
        public UserManager _userManager { get; set; }
        public RoleManager _roleManager { get; set; }
        public SignInManager _signInManager { get; set; }


        public UserService()
        {
        }

        public UserService(UserManager userManager, SignInManager signInManager, RoleManager roleManager, IRepository<User> repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }


        public SignInStatus SignIn(SignIn userSignIn)
        {

            return _signInManager.PasswordSignIn(userSignIn.Email, userSignIn.Password, userSignIn.RememberMe, shouldLockout: false);
        }

        //public IdentityResult ChangePassword (ChangePassword changePassword)
        //{

        //    return _userManager.ChangePassword(changePassword.UserId, changePassword.OldPassword, changePassword.NewPassword);

        //}
    }
}
