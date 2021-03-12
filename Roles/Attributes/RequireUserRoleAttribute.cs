using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireUserRoleAttribute : AuthorizeAttribute
    {
        public RequireUserRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.User;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
