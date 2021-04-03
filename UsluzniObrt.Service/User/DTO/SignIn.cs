using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsluzniObrt.Model
{
    /// <summary>
    /// DTO za SIGNIN
    /// </summary>
    public class SignIn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
