using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireTasksRoleAttribute : AuthorizeAttribute
    {
        public RequireTasksRoleAttribute(string oauthAuthenticationScheme)
        {
            Roles = Common.All.Roles.Roles.Tasks;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{oauthAuthenticationScheme}";
        }
    }
}
