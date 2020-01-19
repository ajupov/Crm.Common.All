using Ajupov.Infrastructure.All.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireSalesRoleAttribute : AuthorizeAttribute
    {
        public RequireSalesRoleAttribute()
        {
            Roles = Common.All.Roles.Roles.Sales;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{JwtDefaults.AuthenticationScheme}";
        }
    }
}