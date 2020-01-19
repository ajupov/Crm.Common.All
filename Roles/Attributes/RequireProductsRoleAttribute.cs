using Ajupov.Infrastructure.All.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Crm.Common.All.Roles.Attributes
{
    public class RequireProductsRoleAttribute : AuthorizeAttribute
    {
        public RequireProductsRoleAttribute()
        {
            Roles = Common.All.Roles.Roles.Products;
            AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},{JwtDefaults.AuthenticationScheme}";
        }
    }
}