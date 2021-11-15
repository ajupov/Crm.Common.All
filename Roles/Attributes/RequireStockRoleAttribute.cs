using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireStockRoleAttribute : AuthorizeAttribute
    {
        public RequireStockRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.Stock;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
