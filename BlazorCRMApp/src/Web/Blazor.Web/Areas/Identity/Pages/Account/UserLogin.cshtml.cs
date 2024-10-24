using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blazor.Web.Areas.Identity.Pages.Account
{
    public class UserLoginModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext != null && HttpContext.User.Identity!.IsAuthenticated)
            {
                return Redirect("/dashboard");
            }
            return Redirect("/login");
        }
    }
}
