using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireOrdersRoleAttribute : AuthorizeAttribute
    {
        public RequireOrdersRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.Orders;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
