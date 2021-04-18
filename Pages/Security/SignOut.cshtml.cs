using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager.Razor.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager.Razor.Pages.Security
{
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SignOutModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Security/SignIn");
        }
    }
}
