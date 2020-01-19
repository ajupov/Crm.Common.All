using Ajupov.Infrastructure.All.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireLeadsRoleAttribute : AuthorizeAttribute
    {
        public RequireLeadsRoleAttribute()
        {
            Roles = Common.All.Roles.Roles.Leads;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{JwtDefaults.AuthenticationScheme}";
        }
    }
}