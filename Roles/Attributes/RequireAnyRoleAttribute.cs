using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireAnyRoleAttribute : AuthorizeAttribute
    {
        public RequireAnyRoleAttribute(string oauthAuthenticationScheme)
        {
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}