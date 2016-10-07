using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using users.Models;
using System.Threading.Tasks;

namespace users.Infrastructure
{
    public class CustomUserValidator : UserValidator<AppUser>
    {
        public CustomUserValidator(AppUserManager mgr) : base(mgr) { }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            //Using the below block of code we can restrict which email domains we'll allow to authenticate

            //if (!user.Email.ToLower().EndsWith("@example.com"))
            //{ 
            //    var errors = result.Errors.ToList();
            //    errors.Add("Only example.com email addresses are allowed"); 
            //    result = new IdentityResult(errors);
            //} 
            return result; 
        }
    }
}