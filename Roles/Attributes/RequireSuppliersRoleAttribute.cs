using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireSuppliersRoleAttribute : AuthorizeAttribute
    {
        public RequireSuppliersRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.Suppliers;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
