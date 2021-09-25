using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireCustomersRoleAttribute : AuthorizeAttribute
    {
        public RequireCustomersRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.Customers;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
