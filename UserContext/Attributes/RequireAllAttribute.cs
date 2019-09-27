using System;

namespace Crm.Common.All.UserContext.Attributes
{
    public class RequireAllAttribute : Attribute
    {
        public RequireAllAttribute(params Permission[] permissions)
        {
        }
    }
}