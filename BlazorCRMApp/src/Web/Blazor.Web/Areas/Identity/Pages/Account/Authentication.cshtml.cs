using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Shared.Lib.Helper;
using Shared.Lib.Enums;
using System;
using Shared.Lib.Dto;

namespace Blazor.Web.Areas.Identity.Pages.Account
{
    public class AuthenticationModel : PageModel
    {
        [FromQuery(Name = "q")]
        public string Q { get; set; } = null!;
        public async Task<IActionResult> OnGet()
        {
            try
            {
                Q = Q!.Replace(" ", "+");
                var userDetails = CommonService.DecryptText(Q, "sblw-3hn8-sqoy19");
                LoginResponseDto user = new LoginResponseDto();
                user = System.Text.Json.JsonSerializer.Deserialize<LoginResponseDto>(userDetails!)!;
                var identity = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Email, user.Email??""),
                        new Claim(ClaimTypes.Name,user.Name??""),
                        new Claim(ClaimTypes.Thumbprint,user.Thumbprint??""),
                        new Claim(ClaimTypes.Role,user.Role),
                        new Claim(ClaimTypes.PrimarySid,user.PrimarySid??""),
                        new Claim("RoleId",user.RoleId??""),
                        new Claim("UserId",$"{user.UserId}" ),
                        new Claim("Short_Url",user.Short_Url??""),
                        new Claim("TimeZone",user.TimeZone??""),
                        new Claim("Logo",user.Logo??""),
                        new Claim("designationPermission",user.designationPermission),
                        new Claim("DateTimeFormat",user.DateTimeFormat??""),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Redirect("/dashboard");

            }
            catch (Exception)
            {
                return Redirect("/account/login");
            }
        }
    }
}
