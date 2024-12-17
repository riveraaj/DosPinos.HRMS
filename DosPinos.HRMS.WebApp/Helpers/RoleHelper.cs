using System.Security.Claims;

namespace DosPinos.HRMS.WebApp.Helpers
{
    public static class RoleHelper
    {
        public static bool HasAnyRole(ClaimsPrincipal user, params int[] roles) =>
            user.Claims.Any(c => c.Type == ClaimTypes.Role && roles.Any(r => c.Value == r.ToString()));
    }
}