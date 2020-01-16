using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Common.All.UserContext
{
    public interface IUserContext
    {
        Guid UserId { get; }

        Guid AccountId { get; }

        List<string> Roles { get; }

        bool HasRoles(params string[] roles) => roles.Intersect(Roles).Any();

        bool Belongs(IEnumerable<Guid> accountIds) => accountIds.All(x => x == AccountId);
    }
}