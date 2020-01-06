using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Common.All.UserContext.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Common.All.UserContext.BaseControllers
{
    public class AllowingCheckControllerBase : ControllerBase
    {
        private readonly IUserContext _userContext;

        public AllowingCheckControllerBase(IUserContext userContext)
        {
            _userContext = userContext;
        }

        [NonAction]
        public async Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            Role[] nonPrivilegedRoles,
            params Guid[] accountIds)
        {
            if (_userContext.HasAny(RequirePrivilegedAttribute.PrivilegedRoles))
            {
                await action();

                return NoContent();
            }

            if (_userContext.HasAny(nonPrivilegedRoles) && _userContext.Belongs(accountIds))
            {
                await action();

                return NoContent();
            }

            if (_userContext.HasAny(Role.AccountOwning) && !_userContext.Belongs(accountIds))
            {
                return Forbid();
            }

            throw new Exception();
        }

        [NonAction]
        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            Role[] nonPrivilegedRoles,
            IEnumerable<Guid> accountIds)
        {
            return ActionIfAllowed(action, nonPrivilegedRoles, accountIds.ToArray());
        }

        [NonAction]
        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            Role nonPrivilegedRole,
            params Guid[] accountIds)
        {
            return ActionIfAllowed(action, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public Task<ActionResult> ActionIfAllowed(
            Func<Task> action,
            Role nonPrivilegedRole,
            IEnumerable<Guid> accountIds)
        {
            return ActionIfAllowed(action, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            Role[] nonPrivilegedRoles,
            params Guid[] accountIds)
        {
            if (_userContext.HasAny(RequirePrivilegedAttribute.PrivilegedRoles))
            {
                return result;
            }

            if (_userContext.HasAny(nonPrivilegedRoles) && _userContext.Belongs(accountIds))
            {
                return result;
            }

            if (_userContext.HasAny(nonPrivilegedRoles) && !_userContext.Belongs(accountIds))
            {
                return Forbid();
            }

            throw new Exception();
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            Role nonPrivilegedRole,
            IEnumerable<Guid> accountIds)
        {
            return ReturnIfAllowed(result, new[] {nonPrivilegedRole}, accountIds.ToArray());
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            Role nonPrivilegedRole,
            params Guid[] accountIds)
        {
            return ReturnIfAllowed(result, new[] {nonPrivilegedRole}, accountIds);
        }

        [NonAction]
        public ActionResult<TResult> ReturnIfAllowed<TResult>(
            TResult result,
            Role[] nonPrivilegedRoles,
            IEnumerable<Guid> accountIds)
        {
            return ReturnIfAllowed(result, nonPrivilegedRoles, accountIds.ToArray());
        }
    }
}
