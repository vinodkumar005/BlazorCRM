using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Blazor.Web.Areas.Identity.Pages.Account
{
    public class AuthenticationModel : PageModel
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; } = null!;

        [FromQuery(Name = "role")]
        public string Role { get; set; } = null!;
        public async Task<IActionResult> OnGet()
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Name),
                    new Claim(ClaimTypes.Role, Role),
                    new Claim("Email", "vinod.kumar@yopmail.com"),
                    new Claim("Address", "Jaipur"),
                    new Claim("Company", "Dotsquares"),
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect("/dashboard");
        }
    }
}
