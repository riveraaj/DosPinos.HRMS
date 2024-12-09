using System.Security.Claims;
using DosPinos.HRMS.Entities.Interfaces.Securities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DosPinos.HRMS.WebApp.Helpers
{
    partial class CookiesHelper
    {
        //This method creates the claims and the cookie for a user session.
        public static async Task CreateAuthenticationCookies(HttpContext oHttpContext, ILoginUserDTO userDTO)
        {

            var claims = new List<Claim> {
                new (ClaimTypes.Role, userDTO.RoleId.ToString()),
                new (ClaimTypes.NameIdentifier, userDTO.UserId.ToString()),
                new ("Employee", userDTO.EmployeeId.ToString()),
                new ("Identification", userDTO.IdentificationId.ToString()),
                new ("Manager", userDTO.ManagerId.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await oHttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                        new ClaimsPrincipal(claimsIdentity));
        }

        //This method deletes cookies from the session.
        public static async Task RemoveAuthenticationCookie(HttpContext oHttpContext)
            => await oHttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}