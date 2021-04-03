using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using UsluzniObrt.Model;


namespace UsluzniObrt.Service
{
    public interface IUserService
    {

        SignInStatus SignIn(SignIn signin);

    }
}
